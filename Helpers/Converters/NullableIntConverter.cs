using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace MyApi.Helpers.Converters
{
    /// <summary>
    /// This class exists because VAT column sometimes contains weird "O" instead of normal number or being empty
    /// </summary>
    public class NullableIntConverter : DefaultTypeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrWhiteSpace(text)) 
                return null;

            if (int.TryParse(text, out int result))
                return result;

            return null;
        }
    }
}