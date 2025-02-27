namespace MyApi.Models.Dto
{
    public class PricesDto
    {
        public string UniqueId { get; set; }
        public string Sku { get; set; }
        public decimal? PriceValue { get; set; }
        public decimal? PriceValueAfterDiscount { get; set; }
        public int? Vat { get; set; }
        public decimal? PriceAfterDiscountForProductLogisticUnit { get; set; }
    }
}
