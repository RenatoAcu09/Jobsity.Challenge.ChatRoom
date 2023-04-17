using Jobsity.Challenge.ChatRoom.Bot.Infra.Configurations;
using Jobsity.Challenge.ChatRoom.Bot.Interfaces.Gateways;
using Jobsity.Challenge.ChatRoom.Core.Infra.Gateways;

namespace Jobsity.Challenge.ChatRoom.Bot.Infra.Gateways
{
    public class GetInfoCommandGateway : BaseGateway<GetInfoCommandGateway>, IGetInfoCommandGateway
    {
        public GetInfoCommandGateway(
                                     IHttpClientFactory httpClientFactory,
                                     ILogger<GetInfoCommandGateway> logger)
            : base(httpClientFactory, logger)
        {
        }

        public async Task<string> GetInfoAsync(AllowedCommandSettings settings, string commandParameter)
        {
            var url = string.Format(settings.QueryString, commandParameter);
            return await SendGetRequest<string>(settings.Name, url);
        }
    }
}