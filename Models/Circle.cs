using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASEL.Models
{
    [Table("CIRCLE")]
    public class Circle
    {
        [Key]
        public long ID { get; set; }

        public string? NAME { get; set; }
    }
}
