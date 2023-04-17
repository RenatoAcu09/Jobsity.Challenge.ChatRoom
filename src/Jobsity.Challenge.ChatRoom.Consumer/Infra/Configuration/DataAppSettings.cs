using Jobsity.Challenge.ChatRoom.Core.Infra.Configurations;

namespace Jobsity.Challenge.ChatRoom.Consumer.Infra.Configuration
{
    public class DataAppSettings
    {
        public string ChatApiUrl { get; set; }

        public int IntervalWorkerActive { get; set; }

        public MessageBrokerSettings MessageBroker { get; set; }
    }
}