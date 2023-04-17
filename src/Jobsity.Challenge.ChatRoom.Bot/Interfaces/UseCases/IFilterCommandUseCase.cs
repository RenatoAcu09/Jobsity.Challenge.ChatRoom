using Jobsity.Challenge.ChatRoom.Bot.Infra.Configurations;

namespace Jobsity.Challenge.ChatRoom.Bot.Interfaces.UseCases
{
    public interface IFilterCommandUseCase
    {
        (AllowedCommandSettings?, string) Filter(string command);
    }
}