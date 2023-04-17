using Jobsity.Challenge.ChatRoom.Core.Infra.Gateways;
using Jobsity.Challenge.ChatRoom.Domain.DataContracts.Requests;
using Jobsity.Challenge.ChatRoom.Infra.Configurations;
using Jobsity.Challenge.ChatRoom.Interfaces.Gateways;
using Microsoft.Extensions.Logging;

namespace Jobsity.Challenge.ChatRoom.Infra.Gateways
{
    public class BotGateway : BaseGateway<BotGateway>, IBotGateway
    {
        public BotGateway(
                          IHttpClientFactory httpClientFactory,
                          ILogger<BotGateway> logger)
            : base(httpClientFactory, logger)
        {
            Client = "commands";
        }

        public async Task PublishCommandAsync(CommandRequest command)
        {
            await SendPostRequest(NamedHttpClients.BotApi, Client, command);
        }
    }
}