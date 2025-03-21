using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASEL.Models
{
    [Table("SITE")]
    public class Site
    {
        [Key]
        public long ID { get; set; }
        public string? NAME { get; set; }

        public long CODE{get;set;}
    }
}
