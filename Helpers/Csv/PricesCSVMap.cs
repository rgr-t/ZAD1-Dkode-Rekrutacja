using CsvHelper.Configuration;
using MyApi.Helpers.Converters;
using MyApi.Models.Prices;
using System.Globalization;

namespace MyApi.Helpers.Csv
{
    public class PricesCSVMap : ClassMap<Price>
    {
        public PricesCSVMap()
        {
            Map(m => m.UniqueId).Index(0);
            Map(m => m.Sku).Index(1);
            Map(m => m.PriceValue).Index(2).TypeConverter<DecimalWithCommaConverter>();
            Map(m => m.PriceValueAfterDiscount).Index(3).TypeConverter<DecimalWithCommaConverter>();
            Map(m => m.Vat).Index(4).TypeConverter<NullableIntConverter>();
            Map(m => m.PriceAfterDiscountForProductLogisticUnit).Index(5).TypeConverter<DecimalWithCommaConverter>();
        }
    }
}