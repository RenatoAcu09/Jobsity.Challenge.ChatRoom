using Jobsity.Challenge.ChatRoom.Bot.Infra.Configurations;
using Jobsity.Challenge.ChatRoom.Core.Infra.Configurations;

namespace Jobsity.Challenge.ChatRoom.Bot.Interfaces.MessageBroker
{
    public interface IMessageBroker
    {
        void Publish<T>(T message, MessageBrokerSettings messageBroker);
    }
}