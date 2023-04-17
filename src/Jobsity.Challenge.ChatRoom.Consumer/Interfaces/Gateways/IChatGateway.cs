using Jobsity.Challenge.ChatRoom.Consumer.Domain.DataContracts.Requests;

namespace Jobsity.Challenge.ChatRoom.Consumer.Interfaces.Gateways
{
    public interface IChatGateway
    {
        Task SendMessageAsyc(CommandMessageRequest request);
    }
}