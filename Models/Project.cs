using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASEL.Models
{
    [Table("PROJECT")]
    public class Project
    {
        [Key]
        public long ID { get; set; }

        public string? NAME { get; set; }
    }
}
