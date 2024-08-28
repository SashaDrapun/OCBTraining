namespace OCBTrainingMainInterface.Models
{
    public class Account
    {
        public int AccountId { get; set; }
        public string? AccountCode { get; set; }
        public int ClassId { get; set; }
        public Class? Class { get; set; }
    }
}
