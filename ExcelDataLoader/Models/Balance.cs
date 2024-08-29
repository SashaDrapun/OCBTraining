using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelDataLoader.Models
{
    public class Balance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BalanceId { get; set; }

        public int AccountId { get; set; }

        public decimal InitialActive { get; set; }

        public decimal InitialPassive { get; set; }

        public decimal FinalActive { get; set; }

        public decimal FinalPassive { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account? Account { get; set; }
    }
}
