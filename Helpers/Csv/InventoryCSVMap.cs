using CsvHelper.Configuration;
using MyApi.Models.Inventory;

namespace MyApi.Helpers.Csv
{
    public class InventoryCSVMap : ClassMap<Inventory>
    {
        public InventoryCSVMap()
        {
            Map(m => m.ProductId).Name("product_id");
            Map(m => m.Sku).Name("sku");
            Map(m => m.Unit).Name("unit");
            Map(m => m.Quantity).Name("qty");
            Map(m => m.ManufacturerName).Name("manufacturer_name");
            Map(m => m.Shipping).Name("shipping");
            Map(m => m.ShippingCost).Name("shipping_cost");
        }
    }
}
