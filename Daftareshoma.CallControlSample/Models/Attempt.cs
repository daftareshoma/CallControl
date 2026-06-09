namespace Daftareshoma.CallControlSample.Models
{
    public class Attempt
    {
        public string To { get; set; }
        public AttemptsStatusEnum Status { get; set; }
        public int RingDuration { get; set; } = 40;
    }
}

