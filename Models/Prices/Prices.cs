namespace MyApi.Models.Prices
{
    public class Prices
    {
        public string UniqueId { get; set; }
        public string Sku { get; set; }
        public float Price { get; set; }
        public float PriceAfterDiscount { get; set; }
        public int Vat { get; set; }
        public float PriceAfterDiscountForProductLogisticUnit { get; set; }
    }
}