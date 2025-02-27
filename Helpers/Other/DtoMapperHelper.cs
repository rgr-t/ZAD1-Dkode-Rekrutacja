using MyApi.Models.Dto;
using MyApi.Models.Inventory;
using MyApi.Models.Prices;
using MyApi.Models.Products;
using System.Globalization;

namespace MyApi.Helpers.Other
{
    public static class DtoMapperHelper
    {
        public static ProductDto MapProduct(Product p) => new ProductDto
        {
            Id = p.Id,
            Sku = p.Sku,
            ProducerName = p.ProducerName,
            MainCategory = p.Category?.Split('|').FirstOrDefault(),
            SubCategory = p.Category?.Split('|').ElementAtOrDefault(1), 
            IsVendor = p.IsVendor            
        };

        public static StockItemDto MapStockItem(Inventory s) => new StockItemDto
        {
            ProductId = s.ProductId,
            Sku = s.Sku,
            Unit = s.Unit,
            Quantity = TryParseDecimal(s.Quantity),
            ManufacturerName = s.ManufacturerName,
            Shipping = s.Shipping,
            ShippingCost = TryParseDecimal(s.ShippingCost)
        };

        public static PricesDto MapPrice(Price p) => new PricesDto
        {            
            Sku = p.Sku,            
            PriceAfterDiscount = p.PriceValueAfterDiscount,
            Vat = p.Vat,
            PriceAfterDiscountForProductLogisticUnit = p.PriceAfterDiscountForProductLogisticUnit
        };

        private static decimal TryParseDecimal(string input)
        {
            if (decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                return result;

            return 0m;
        }
    }
}