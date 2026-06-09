namespace Daftareshoma.CallControlSample.Models
{
    public class AutomaticTransferResult
    {
        public AutomaticTransferStatusEnum Status { get; set; }
        public string? ConnectedTo { get; set; }
        public List<Attempt> Attempts { get; set; }
    }
}

