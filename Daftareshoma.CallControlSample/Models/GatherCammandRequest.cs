namespace Daftareshoma.CallControlSample.Models
{
    public class GatherCammandRequest
    {
        public string CommandId { get; set; }
        public string CommandName { get; set; }
        public string CallId { get; set; }
        public string Text { get; set; }
        public string Voice { get; set; }
        public string Input { get; set; }
        public string FinishOnkey { get; set; }
        public int NumDigits { get; set; }
        public int Timeout { get; set; }
       
    }
}
