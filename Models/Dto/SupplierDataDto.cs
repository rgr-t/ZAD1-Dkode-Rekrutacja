namespace MyApi.Models.Dto
{
    public class SupplierDataDto
    {
        public string SupplierName { get; set; }
        public string MainCategory { get; set; }
        public string SubCategory { get; set; }
        public int TotalStockQuantity { get; set; }
        public decimal AvgPriceIncludingVAT { get; set; }
        public decimal TotalStockValueIncludingVAT { get; set; }
        public string ShippedBy { get; set; }
    }
}
