namespace OCBTrainingMainInterface.Models
{
    public class Balance
    {
        public int BalanceId { get; set; }
        public int AccountId { get; set; }
        public decimal InitialActive { get; set; }
        public decimal InitialPassive { get; set; }
        public decimal FinalActive { get; set; }
        public decimal FinalPassive { get; set; }
        public Account? Account { get; set; }
    }
}
