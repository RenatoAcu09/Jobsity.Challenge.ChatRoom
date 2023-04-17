using Jobsity.Challenge.ChatRoom.Consumer.Domain.DataContracts.Requests;
using Jobsity.Challenge.ChatRoom.Consumer.Infra.Configuration;
using Jobsity.Challenge.ChatRoom.Consumer.Interfaces.Gateways;
using Jobsity.Challenge.ChatRoom.Core.Infra.Gateways;

namespace Jobsity.Challenge.ChatRoom.Consumer.Infra.Gateways
{
    public class ChatGateway : BaseGateway<ChatGateway>, IChatGateway
    {
        public ChatGateway(
                           IHttpClientFactory httpClientFactory,
                           ILogger<ChatGateway> logger)
            : base(httpClientFactory, logger)
        {
        }

        public async Task SendMessageAsyc(CommandMessageRequest request)
        {
            var url = "chat/send-command";
            await SendPostRequest(NamedHttpClients.Chat, url, request);
        }
    }
}