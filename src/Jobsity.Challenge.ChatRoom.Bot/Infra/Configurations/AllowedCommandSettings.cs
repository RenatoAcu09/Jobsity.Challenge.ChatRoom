using Jobsity.Challenge.ChatRoom.Core.Infra.Configurations;

namespace Jobsity.Challenge.ChatRoom.Bot.Infra.Configurations
{
    public class AllowedCommandSettings
    {
        public string BaseUrl { get; set; }

        public string Command { get; set; }

        public string Converter { get; set; }

        public string Name { get; set; }

        public string QueryString { get; set; }

        public MessageBrokerSettings MessageBroker { get; set; }
    }
}