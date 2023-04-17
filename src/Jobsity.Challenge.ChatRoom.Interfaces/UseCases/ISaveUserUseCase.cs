using Jobsity.Challenge.ChatRoom.Domain.Dtos;

namespace Jobsity.Challenge.ChatRoom.Interfaces.UseCases
{
    public interface ISaveUserUseCase
    {
        Task<UserDto> SaveUser(NewUserDto newUserDto, string connectionId);
    }
}