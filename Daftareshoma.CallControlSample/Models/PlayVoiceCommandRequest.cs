namespace Daftareshoma.CallControlSample.Models
{
    public class PlayVoiceCommandRequest
    {
        public string Url { get; set; }
        public string CommandId { get; set; }
        public string CommandName { get; set; }
        public string CallId { get; set; }
    }
}
