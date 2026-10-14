namespace Daftareshoma.CallControlSample.Models
{
    public class RecordCommandRequest
    {
        public string CommandId { get; set; }
        public string CommandName { get; set; }
        public string CallId { get; set; }
        public int? MaxDuration { get; set; }
        public int SilenceTimeout { get; set; } = 5;
        public bool Beep { get; set; } = true;
    }
}
