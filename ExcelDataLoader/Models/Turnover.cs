using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelDataLoader.Models
{
    public class Turnover
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TurnoverId { get; set; }

        public int AccountId { get; set; }

        public decimal Debit { get; set; }

        public decimal Credit { get; set; }

        [ForeignKey("AccountId")]
        public virtual Account? Account { get; set; }
    }
}
