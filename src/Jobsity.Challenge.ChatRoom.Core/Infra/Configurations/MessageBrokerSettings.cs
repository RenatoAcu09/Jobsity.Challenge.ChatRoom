﻿namespace Jobsity.Challenge.ChatRoom.Core.Infra.Configurations
{
    public class MessageBrokerSettings
    {
        public string ConnectionString { get; set; }

        public string Queue { get; set; }

        public string RoutingKey { get; set; }
    }
}