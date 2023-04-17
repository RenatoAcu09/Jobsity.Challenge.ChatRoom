using Jobsity.Challenge.ChatRoom.Domain.Dtos;

namespace Jobsity.Challenge.ChatRoom.Interfaces.UseCases
{
    public interface IDispatchCommandUseCase
    {
        Task DispatchAsync(ChatMessageDto chatMessage);
    }
}