using ExcelDataLoader.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AccountId { get; set; }

    public string? AccountCode { get; set; }

    public int ClassId { get; set; }

    [ForeignKey("ClassId")]
    public virtual Class? Class { get; set; }

    public ICollection<Balance> Balances { get; set; } = new List<Balance>();
    public ICollection<Turnover> Turnovers { get; set; } = new List<Turnover>();
}