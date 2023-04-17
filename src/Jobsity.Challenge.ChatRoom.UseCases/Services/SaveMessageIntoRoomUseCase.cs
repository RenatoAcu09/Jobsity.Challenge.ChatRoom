using AutoMapper;
using Jobsity.Challenge.ChatRoom.Domain.Dtos;
using Jobsity.Challenge.ChatRoom.Domain.Entities;
using Jobsity.Challenge.ChatRoom.Interfaces.Repositories;
using Jobsity.Challenge.ChatRoom.Interfaces.UseCases;

namespace Jobsity.Challenge.ChatRoom.UseCases.Services
{
    public class SaveMessageIntoRoomUseCase : ISaveMessageIntoRoomUseCase
    {
        private readonly IChatRoomRepository _chatRoomRepository;

        private readonly IMapper _mapper;

        public SaveMessageIntoRoomUseCase(
                                          IChatRoomRepository chatRoomRepository,
                                          IMapper mapper)
        {
            _chatRoomRepository = chatRoomRepository ?? throw new ArgumentNullException(nameof(chatRoomRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task SaveAsync(ChatMessageDto chatMessageDto)
        {
            var chatMessage = _mapper.Map<ChatMessage>(chatMessageDto);
            await _chatRoomRepository.SaveNewMessageAsync(chatMessage);
        }
    }
}