using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System.Globalization;

namespace MyApi.Helpers.Converters
{
    public class DecimalWithCommaConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text)) 
                return null;

            text = text.Replace(",", ".");

            if (decimal.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))            
                return result;
            
            return null;
        }
    }
}