namespace Jobsity.Challenge.ChatRoom.Infra.Configurations
{
    public class DataAppSettings
    {
        public string[] AllowedCommands { get; set; }

        public ApiSettings Apis { get; set; }

        public int LimitOfMessagesPerRoom { get; set; }
    }
}