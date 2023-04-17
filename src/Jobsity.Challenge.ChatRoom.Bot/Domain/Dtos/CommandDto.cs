namespace Jobsity.Challenge.ChatRoom.Bot.Domain.Dtos
{
    public class CommandDto
    {
        public Guid Destination { get; set; }

        public string Message { get; set; }

        public string CommandParameter;

        public Guid SenderId { get; set; }
    }
}