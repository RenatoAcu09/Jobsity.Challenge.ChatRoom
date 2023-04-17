using Jobsity.Challenge.ChatRoom.Bot.Infra.Configurations;

namespace Jobsity.Challenge.ChatRoom.Bot.Interfaces.Gateways
{
    public interface IGetInfoCommandGateway
    {
        Task<string> GetInfoAsync(AllowedCommandSettings settings, string commandParameter);
    }
}