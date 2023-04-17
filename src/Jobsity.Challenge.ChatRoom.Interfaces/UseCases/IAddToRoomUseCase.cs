using Jobsity.Challenge.ChatRoom.Domain.Dtos;

namespace Jobsity.Challenge.ChatRoom.Interfaces.UseCases
{
    public interface IAddToRoomUseCase
    {
        Task<ChatRoomDto?> AddAsync(string roomName, Guid userId);
    }
}