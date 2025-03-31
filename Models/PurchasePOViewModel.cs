namespace BASEL.Models
{
    using Newtonsoft.Json;

    public class PurchasePOViewModel
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("po_id")]
        public long PoId { get; set; }

        [JsonProperty("site_id")]
        public long SiteId { get; set; }

        [JsonProperty("site_nm")]
        public string? SiteNm { get; set; }

        [JsonProperty("customer_code")]
        public string? CustomerCode { get; set; }

        [JsonProperty("cust_item_name")]
        public string? CustItemName { get; set; }

        [JsonProperty("unit")]
        public long Unit { get; set; }

        [JsonProperty("rate")]
        public long Rate { get; set; }

        [JsonProperty("amount")]
        public long Amount { get; set; }
    }

}
