namespace OCBTrainingMainInterface.Models
{
    public class Turnover
    {
        public int TurnoverId { get; set; }
        public int AccountId { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public Account? Account { get; set; }
    }
}
