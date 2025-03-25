using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BASEL.Models
{
    [Table("PURCHASE_DETAILS")]
    public class PurchaseDetails
    {
        [Key]
        public long PO_ID { get; set; }
        public long PO_NO { get; set; }
        public DateOnly PO_DATE { get; set; } // Using DateOnly for dates
        public string? CUSTOMER { get; set; }  // Changed from long to string (as per table)
        public string? CIRCLE { get; set; }
        public string? PROJECT { get; set; }   // Changed from long to string (as per table)
        public string? ACTIVITY { get; set; }
    }
}
