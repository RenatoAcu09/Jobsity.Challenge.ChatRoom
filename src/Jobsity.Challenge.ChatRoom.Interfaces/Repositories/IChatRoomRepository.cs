using Jobsity.Challenge.ChatRoom.Domain.Entities;

namespace Jobsity.Challenge.ChatRoom.Interfaces.Repositories
{
    public interface IChatRoomRepository
    {
        Task<ChatRoom.Domain.Entities.ChatRoom> AddUser(string roomName, User user);

        Task<IEnumerable<ChatRoom.Domain.Entities.ChatRoom>> GetAllRooms();

        Task<ChatRoom.Domain.Entities.ChatRoom> GetRoomById(Guid id);

        Task<ChatRoom.Domain.Entities.ChatRoom> GetRoomByName(string roomName);

        Task<ChatRoom.Domain.Entities.ChatRoom> GetRoomByNameAndUser(string roomName, Guid userId);

        Task<bool> HasUser(string roomName, User user);

        Task RemoveUser(string roomName, User user);

        Task SaveNewMessageAsync(ChatMessage chatMessage);
    }
}