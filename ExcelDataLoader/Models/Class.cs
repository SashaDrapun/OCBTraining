using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelDataLoader.Models
{
    public class Class
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClassId { get; set; }

        public string? ClassName { get; set; }

        public int UploadedFileId { get; set; }

        [ForeignKey("UploadedFileId")]
        public virtual UploadedFile? UploadedFile { get; set; }

        public ICollection<Account> Accounts { get; set; } = new List<Account>();

        public ICollection<ClassTotal> ClassTotals { get; set; } = new List<ClassTotal>();
    }
}
