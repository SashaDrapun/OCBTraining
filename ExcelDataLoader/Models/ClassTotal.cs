using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelDataLoader.Models
{
    public class ClassTotal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ClassId { get; set; } 

        public decimal InitialActive { get; set; }

        public decimal InitialPassive { get; set; }

        public decimal TurnoverDebit { get; set; }

        public decimal TurnoverCredit { get; set; }

        public decimal FinalActive { get; set; }

        public decimal FinalPassive { get; set; }

        [ForeignKey("ClassId")]
        public virtual Class? Class { get; set; }
    }
}
