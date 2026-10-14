namespace Daftareshoma.CallControlSample.Models
{
    public class PlayTextCommandRequest
    {
        public string Text { get; set; }
        public string Voice { get; set; }
        public string CommandId { get; set; }
        public string CommandName { get; set; }
        public string CallId { get; set; }
    }
}
