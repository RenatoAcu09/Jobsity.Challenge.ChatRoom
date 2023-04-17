using Jobsity.Challenge.ChatRoom.Domain.Entities;

namespace Jobsity.Challenge.ChatRoom.Interfaces.Repositories
{
    public interface IUserConnectionRepository
    {
        Task<List<User>> GetAllUser();

        Task<User> GetUser(Guid id);

        Task<User> GetUserByConnectionId(string connectionId);

        Task Save(User user);
    }
}