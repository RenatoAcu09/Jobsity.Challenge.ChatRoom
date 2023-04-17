using Jobsity.Challenge.ChatRoom.Domain.DataContracts.Requests;
using Jobsity.Challenge.ChatRoom.Domain.Dtos;
using Jobsity.Challenge.ChatRoom.Interfaces.Gateways;
using Jobsity.Challenge.ChatRoom.Interfaces.UseCases;

namespace Jobsity.Challenge.ChatRoom.UseCases.Services
{
    public class DispatchCommandUseCase : IDispatchCommandUseCase
    {
        private readonly IBotGateway _botGateway;

        public DispatchCommandUseCase(IBotGateway botGateway)
        {
            _botGateway = botGateway ?? throw new ArgumentNullException(nameof(botGateway));
        }

        public async Task DispatchAsync(ChatMessageDto chatMessage)
        {
            var request = new CommandRequest
            {
                Destination = chatMessage.Destination,
                Message = chatMessage.Message,
                SenderId = chatMessage.Sender.Id
            };
            await _botGateway.PublishCommandAsync(request);
        }
    }
}