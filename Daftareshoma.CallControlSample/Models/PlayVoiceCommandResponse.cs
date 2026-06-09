namespace Daftareshoma.CallControlSample.Models
{
    public class PlayVoiceCommandResponse
    {
        public string CallId { get; set; }
        public Guid CommandId { get; set; }
        public PlayResult PlayResult { get; set; }
    }
}
