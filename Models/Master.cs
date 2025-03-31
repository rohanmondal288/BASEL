using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASEL.Models
{
    [Table("MASTER")]  // The table name is explicitly defined here
    public class Master
    {
        // Marks this property as the primary key for the table
        [Key]
        public long ID { get; set; }

        public string? NAME { get; set; }
        public string? CUSTOMER_CODE { get; set; }
    }
}
