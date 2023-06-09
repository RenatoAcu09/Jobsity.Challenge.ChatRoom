﻿using Jobsity.Challenge.ChatRoom.Domain.Constants;
using Jobsity.Challenge.ChatRoom.Domain.Dtos;
using Jobsity.Challenge.ChatRoom.Interfaces.UseCases;
using Jobsity.Challenge.ChatRoom.SignalR.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Jobsity.Challenge.ChatRoom.SignalR.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        #region " FIELDS "

        private readonly IGetUserUseCase _getUserUseCase;

        private readonly IHubContext<ChatHub> _hubContext;

        private readonly ILogger<ChatController> _logger;
        
        #endregion " FIELDS "

        public ChatController(
                              IHubContext<ChatHub> hubContext,
                              IGetUserUseCase getUserUseCase,
                              ILogger<ChatController> logger)
        {
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
            _getUserUseCase = getUserUseCase ?? throw new ArgumentNullException(nameof(getUserUseCase));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpPost("send-command")]
        public async Task<IActionResult> SendMessageCommand(CommandMessageDto message)
        {
            var user = await _getUserUseCase.GetUserById(message.SenderId);
            if (user is null ||
                _hubContext.Clients.Client(user.ConnectionId) is null)
            {
                _logger.LogWarning("User {UserId} is not connected anymore into the chat.", message.SenderId);
            }
            else
            {
                await SendMessageCommand(new ChatMessageDto(message.Destination, message.Message, user));
            }

            return Ok();
        }

        private async Task SendMessageCommand(ChatMessageDto chatMessage)
        {
            try
            {
                await _hubContext.Clients.Client(chatMessage.Sender.ConnectionId).SendAsync(ConstantsHubs.CommandReceived, new ChatMessageDto(chatMessage.Destination, chatMessage.Message));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error trying to send a message command to {UserConnectionId}.", chatMessage?.Sender.ConnectionId);
                await _hubContext.Clients.Client(chatMessage.Sender.ConnectionId).SendAsync(ConstantsHubs.CommandReceived, new ChatMessageDto(chatMessage.Destination, "Error while sending message/command."));
            }
        }
    }
}
