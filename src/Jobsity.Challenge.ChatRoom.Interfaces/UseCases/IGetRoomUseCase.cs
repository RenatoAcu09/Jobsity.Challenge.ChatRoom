using Jobsity.Challenge.ChatRoom.Domain.Dtos;

namespace Jobsity.Challenge.ChatRoom.Interfaces.UseCases
{
    public interface IGetRoomUseCase
    {
        Task<IEnumerable<ChatRoomDto>> GetAll();

        Task<ChatRoomDto> GetByNameAndUser(string groupName, Guid userId);
    }
}