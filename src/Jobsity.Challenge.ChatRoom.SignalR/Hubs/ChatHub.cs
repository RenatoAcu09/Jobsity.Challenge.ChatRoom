﻿using Jobsity.Challenge.ChatRoom.Domain.Constants;
using Jobsity.Challenge.ChatRoom.Domain.Dtos;
using Jobsity.Challenge.ChatRoom.Infra.Configurations;
using Jobsity.Challenge.ChatRoom.Interfaces.UseCases;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

namespace Jobsity.Challenge.ChatRoom.SignalR.Hubs
{
    public class ChatHub : Hub
    {
        #region " FIELDS "

        private readonly IAddToRoomUseCase _addToRoomUseCase;

        private readonly DataAppSettings _dataAppSettings;

        private readonly IDispatchCommandUseCase _dispatchCommandUseCase;

        private readonly IGetRoomUseCase _getRoomUseCase;

        private readonly IGetUserUseCase _getUserUseCase;

        private readonly ILogger<ChatHub> _logger;

        private readonly ISaveMessageIntoRoomUseCase _saveMessageIntoRoomUseCase;

        private readonly ISaveUserUseCase _saveUserUseCase;

        #endregion " FIELDS "

        #region " CONSTRUCTOR "

        public ChatHub(
                       IAddToRoomUseCase addToRoomUseCase,
                       IGetRoomUseCase getRoomUseCase,
                       IGetUserUseCase getUserUseCase,
                       ISaveUserUseCase saveUserUseCase,
                       ISaveMessageIntoRoomUseCase saveMessageIntoRoomUseCase,
                       IDispatchCommandUseCase dispatchCommandUseCase,
                       DataAppSettings dataAppSettings,
                       ILogger<ChatHub> logger)
        {
            _addToRoomUseCase = addToRoomUseCase ?? throw new ArgumentNullException(nameof(addToRoomUseCase));
            _getRoomUseCase = getRoomUseCase ?? throw new ArgumentNullException(nameof(getRoomUseCase));
            _getUserUseCase = getUserUseCase ?? throw new ArgumentNullException(nameof(getUserUseCase));
            _saveUserUseCase = saveUserUseCase ?? throw new ArgumentNullException(nameof(saveUserUseCase));
            _saveMessageIntoRoomUseCase = saveMessageIntoRoomUseCase ?? throw new ArgumentNullException(nameof(saveMessageIntoRoomUseCase));
            _dispatchCommandUseCase = dispatchCommandUseCase ?? throw new ArgumentNullException(nameof(dispatchCommandUseCase));
            _dataAppSettings = dataAppSettings ?? throw new ArgumentNullException(nameof(dataAppSettings));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #endregion " CONSTRUCTOR "

        #region " PUBLIC METHODS "

        public async Task AddToChatRoom(string groupName)
        {
            try
            {
                var user = await _getUserUseCase.GetUserByConnectionId(Context.ConnectionId);
                var room = await _getRoomUseCase.GetByNameAndUser(groupName, user.Id);
                if (room == null)
                {
                    room = await _addToRoomUseCase.AddAsync(groupName, user.Id);
                    await AddAndNotifyNewUserRoom(user, room);
                    await Clients.OthersInGroup(room.Id.ToString()).SendAsync(ConstantsHubs.Receive, new ChatMessageDto(room.Id, $"{user.Name} has joined the group {groupName}."));
                }
                else
                {
                    await AddAndNotifyNewUserRoom(user, room);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to add the user to the group {GroupName}.", groupName);
            }
        }

        public override async Task OnConnectedAsync()
        {
            try
            {
                var userDto = JsonConvert.DeserializeObject<NewUserDto>(Context.GetHttpContext().Request.Query["user"]);
                var user = await _saveUserUseCase.SaveUser(userDto, Context.ConnectionId);

                var rooms = await _getRoomUseCase.GetAll();
                await Clients.Caller.SendAsync(ConstantsHubs.UserData, user);
                await Clients.Caller.SendAsync(ConstantsHubs.DefaultChat, rooms, user);

                await base.OnConnectedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to connect the user.");
            }
        }

        public async Task SendMessage(ChatMessageDto chatMessage)
        {
            try
            {
                if (chatMessage.Message.ToString().Trim() != "")
                {
                    if (chatMessage.IsCommand())
                    {
                        await HandleCommand(chatMessage);
                    }
                    else
                    {
                        await _saveMessageIntoRoomUseCase.SaveAsync(chatMessage);
                        await Clients.Group(chatMessage.Destination.ToString()).SendAsync(ConstantsHubs.Receive, chatMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to send a message to the group {GroupName}.", chatMessage?.Destination);
                await Clients.Caller.SendAsync(ConstantsHubs.Receive, new ChatMessageDto(chatMessage.Destination, "Error while sending message/command."));
            }
        }

        #endregion " PUBLIC METHODS "

        #region " PRIVATE METHODS "

        private async Task AddAndNotifyNewUserRoom(UserDto user, ChatRoomDto room)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, room.Id.ToString());
            await Clients.All.SendAsync(ConstantsHubs.DefaultChat, await _getRoomUseCase.GetAll(), user);
        }

        private async Task HandleCommand(ChatMessageDto chatMessage)
        {
            var message = string.Empty;
            if (_dataAppSettings.AllowedCommands.Any(c => chatMessage.Message.ToLower().StartsWith(c)))
            {
                await _dispatchCommandUseCase.DispatchAsync(chatMessage);
                message = $"Processing command {chatMessage.Message}";
            }
            else
            {
                message = $"Invalid command {chatMessage.Message}";
            }

            await Clients.Caller.SendAsync(ConstantsHubs.CommandReceived, new ChatMessageDto(chatMessage.Destination, message));
        }

        #endregion " PRIVATE METHODS "
    }
}