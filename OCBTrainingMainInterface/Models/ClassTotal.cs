namespace OCBTrainingMainInterface.Models
{
    public class ClassTotal
    {
        public int ClassId { get; set; }
        public decimal InitialActive { get; set; }
        public decimal InitialPassive { get; set; }
        public decimal TurnoverDebit { get; set; }
        public decimal TurnoverCredit { get; set; }
        public decimal FinalActive { get; set; }
        public decimal FinalPassive { get; set; }
        public Class? Class { get; set; }
    }
}
