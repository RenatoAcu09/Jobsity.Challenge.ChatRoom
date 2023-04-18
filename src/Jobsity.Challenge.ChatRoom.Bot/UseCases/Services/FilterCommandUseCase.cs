using Jobsity.Challenge.ChatRoom.Bot.Infra.Configurations;
using Jobsity.Challenge.ChatRoom.Bot.Interfaces.UseCases;
using System.Text.RegularExpressions;

namespace Jobsity.Challenge.ChatRoom.Bot.UseCases.Services
{
    public class FilterCommandUseCase : IFilterCommandUseCase
    {
        private readonly DataAppSettings _dataAppSettings;

        public FilterCommandUseCase(DataAppSettings dataAppSettings)
        {
            _dataAppSettings = dataAppSettings ?? throw new ArgumentNullException(nameof(dataAppSettings));
        }

        public (AllowedCommandSettings?, string) Filter(string command)
        {
            foreach (var allowedCommand in _dataAppSettings.AllowedCommands)
            {
                var regex = new Regex($"(?<={allowedCommand.Command}).*").Matches(command.ToLower());
                if (regex.Count > 0)
                {
                    return (allowedCommand, regex.First().Value);
                }
            }

            return (null, string.Empty);
        }
    }
}