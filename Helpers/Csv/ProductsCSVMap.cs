using CsvHelper.Configuration;
using MyApi.Models.Products;

namespace MyApi.Helpers.Csv
{
    public class ProductsCSVMap : ClassMap<Products>
    {
        public ProductsCSVMap()
        {
            Map(m => m.Id).Name("ID");
            Map(m => m.Sku).Name("SKU");
            Map(m => m.Name).Name("name");
            Map(m => m.Ean).Name("EAN");
            Map(m => m.ProducerName).Name("producer_name");
            Map(m => m.Category).Name("category");
            Map(m => m.IsWire).Name("is_wire");
            Map(m => m.Shipping).Name("shipping");
            Map(m => m.Available).Name("available");
            Map(m => m.IsVendor).Name("is_vendor");
            Map(m => m.DefaultImage).Name("default_image");
        }
    }
}
