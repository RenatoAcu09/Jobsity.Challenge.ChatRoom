using Jobsity.Challenge.ChatRoom.Domain.DataContracts.Requests;

namespace Jobsity.Challenge.ChatRoom.Interfaces.Gateways
{
    public interface IBotGateway
    {
        Task PublishCommandAsync(CommandRequest command);
    }
}