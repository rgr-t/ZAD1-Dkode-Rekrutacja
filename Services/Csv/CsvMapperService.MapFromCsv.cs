using CsvHelper;
using CsvHelper.Configuration;
using MyApi.Models.Results.Csv;
using System.Globalization;

namespace MyApi.Services.Csv
{
    public partial class CsvMapperService
    {
        public async Task<CsvMappingResult<T>> MapFromCsv<T>(byte[] file, ClassMap<T> classMap, bool hasHeader, string separator, CultureInfo cultureInfo)
        {
            try
            {                
                var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = separator,
                    MissingFieldFound = null,
                    HeaderValidated = null,
                    BadDataFound = null,
                    HasHeaderRecord = hasHeader
                };

                using (var stream = new MemoryStream(file))  
                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader, csvConfiguration))
                {
                    csv.Context.RegisterClassMap(classMap);

                    var records = new List<T>();

                    await foreach (var record in csv.GetRecordsAsync<T>())
                    {
                        records.Add(record);
                    }

                    return new CsvMappingResult<T>()
                    {
                        Success = true,
                        Message = $"Successfully mapped csv file content to class of type {typeof(T).Name}",
                        Data = records,

                    };                
                }

            }
            catch(CsvHelperException ex)
            {
                return new CsvMappingResult<T>()
                {
                    Success = false,
                    Message = $"Csv helper exception: {ex.Message}"
                };
            }
            catch(Exception ex) 
            {
                return new CsvMappingResult<T>()
                {
                    Success = false,
                    Message = $"Unexpected exception: {ex.Message}"
                }; 
            }            
        }
    }
}
