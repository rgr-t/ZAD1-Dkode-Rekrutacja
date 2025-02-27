namespace MyApi.Models.Dto
{
    public class PricesDto
    {        
        public string Sku { get; set; }        
        public decimal? PriceAfterDiscount { get; set; }
        public int? Vat { get; set; }
        public decimal? PriceAfterDiscountForProductLogisticUnit { get; set; }
    }
}
