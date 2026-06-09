namespace Daftareshoma.CallControlSample.Models
{
    public class InitialCallWebhook
    {
        public string CallId { get; set; } = "";
        public string From { get; set; } = "";
        public string To { get; set; } = "";
        public DateTime StartAt { get; set; }
    }
}
