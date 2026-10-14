namespace Daftareshoma.CallControlSample.Models
{
    public class QueueCommandRequest
    {
        public Guid QueueId { get; set; }
        public string CommandId { get; set; }
        public string CommandName { get; set; }
        public string CallId { get; set; }
    }
}
