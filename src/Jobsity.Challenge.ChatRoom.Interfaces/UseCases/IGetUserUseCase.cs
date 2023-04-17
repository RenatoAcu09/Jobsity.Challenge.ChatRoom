using Jobsity.Challenge.ChatRoom.Domain.Dtos;

namespace Jobsity.Challenge.ChatRoom.Interfaces.UseCases
{
    public interface IGetUserUseCase
    {
        Task<UserDto> GetUserByConnectionId(string connectionId);

        Task<UserDto> GetUserById(Guid id);
    }
}