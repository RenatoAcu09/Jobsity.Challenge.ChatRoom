using Jobsity.Challenge.ChatRoom.Domain.Entities;

namespace Jobsity.Challenge.ChatRoom.Interfaces.Repositories
{
    public interface IChatRoomRepository
    {
        Task<ChatRoom_> AddUser(string roomName, User user);

        Task<IEnumerable<ChatRoom_>> GetAllRooms();

        Task<ChatRoom_> GetRoomById(Guid id);

        Task<ChatRoom_> GetRoomByName(string roomName);

        Task<ChatRoom_> GetRoomByNameAndUser(string roomName, Guid userId);

        Task<bool> HasUser(string roomName, User user);

        Task RemoveUser(string roomName, User user);

        Task SaveNewMessageAsync(ChatMessage chatMessage);
    }
}