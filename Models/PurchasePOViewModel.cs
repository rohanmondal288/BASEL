namespace BASEL.Models
{
    public class PurchasePOViewModel
    {
        public long PoId { get; set; }
        public long SiteId { get; set; }
        public string ?SiteNm { get; set; }
        public long CustItem { get; set; }
        public string ?CustItemName { get; set; }
        public long Unit { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount { get; set; }
    }
}
