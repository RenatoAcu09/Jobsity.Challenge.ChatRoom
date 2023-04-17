namespace Jobsity.Challenge.ChatRoom.Domain.Dtos
{
    public class CommandMessageDto
    {
        public Guid Destination { get; set; }

        public string Message { get; set; }

        public Guid SenderId { get; set; }
    }
}