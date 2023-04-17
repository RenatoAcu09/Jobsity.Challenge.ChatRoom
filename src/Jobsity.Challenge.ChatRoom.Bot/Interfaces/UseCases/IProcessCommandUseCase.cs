using Jobsity.Challenge.ChatRoom.Bot.Domain.Dtos;
using Jobsity.Challenge.ChatRoom.Bot.Infra.Configurations;

namespace Jobsity.Challenge.ChatRoom.Bot.Interfaces.UseCases
{
    public interface IProcessCommandUseCase
    {
        Task ProcessAsync(CommandDto command, AllowedCommandSettings allowedCommand, CancellationToken cancellationToken);
    }
}