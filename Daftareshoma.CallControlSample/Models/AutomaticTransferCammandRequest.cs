namespace Daftareshoma.CallControlSample.Models
{
    public class AutomaticTransferCammandRequest
    {
        public string MusicOnHold { get; set; }
        public List<Number> Numbers { get; set; }

        public string CommandId { get; set; }
        public string CommandName { get; set; }
        public string CallId { get; set; }
    }
}
