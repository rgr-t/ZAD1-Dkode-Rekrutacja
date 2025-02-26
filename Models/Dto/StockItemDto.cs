namespace MyApi.Models.Dto
{
    public class StockItemDto
    {
        public int ProductId { get; set; }
        public string Sku { get; set; }
        public string Unit { get; set; }
        public decimal Quantity { get; set; }
        public string ManufacturerName { get; set; }
        public string Shipping { get; set; }
        public decimal ShippingCost { get; set; }
    }
}