namespace Daftareshoma.CallControlSample.Models
{
    public class HangupCommandResponse
    {
        public string CallId { get; set; }
        public string CommandId { get; set; }
        public HangupResult HangupResult { get; set; }
    }
    public class HangupResult
    {
        public hangupStatusEnum HangupStatusEnum { get; set; }
        public string Error { get; set; }
    }
    public enum hangupStatusEnum
    {
        Completed,
        Failed,
    }
}
