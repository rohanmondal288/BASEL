namespace BASEL.Models
{
    using Newtonsoft.Json;

    public class PURCHASE_PO
    {
        public long Id { get; set; }

        [JsonProperty("pO_ID")]
        public long PoId { get; set; }

        [JsonProperty("sitE_ID")]
        public long SiteId { get; set; }

        [JsonProperty("sitE_NM")]
        public string SiteNm { get; set; }

        [JsonProperty("customeR_CODE")]
        public string CustomerCode { get; set; }

        [JsonProperty("cusT_ITEM_NAME")]
        public string CustItemName { get; set; }

        public long Unit { get; set; }
        public long Rate { get; set; }
        public long Amount { get; set; }
    }

}
