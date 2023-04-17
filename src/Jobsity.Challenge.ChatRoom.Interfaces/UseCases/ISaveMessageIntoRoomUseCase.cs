using Jobsity.Challenge.ChatRoom.Domain.Dtos;

namespace Jobsity.Challenge.ChatRoom.Interfaces.UseCases
{
    public interface ISaveMessageIntoRoomUseCase
    {
        Task SaveAsync(ChatMessageDto chatMessageDto);
    }
}