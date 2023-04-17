namespace Jobsity.Challenge.ChatRoom.Consumer.Domain.DataContracts.Requests
{
    public class CommandMessageRequest
    {
        public Guid Destination { get; set; }

        public string Message { get; set; }

        public Guid SenderId { get; set; }
    }
}