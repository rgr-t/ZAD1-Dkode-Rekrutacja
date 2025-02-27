using CsvHelper;
using CsvHelper.Configuration;
using MyApi.Models.Results.Csv;
using System.Globalization;

namespace MyApi.Services.Csv
{
    public partial class CsvMapperService
    {
        //Csv file mapping method, using byte array with csv content and csv helper classMap to chose class type.         
        public async Task<CsvMappingResult<T>> MapFromCsv<T>(byte[] file, ClassMap<T> classMap, bool hasHeader, string separator)
        {
            if (file == null || file.Length == 0)
            {
                return new CsvMappingResult<T>()
                {
                    Success = false,
                    Message = $"Error before mapping csv file to {classMap.GetType().Name} class, file content was null or empty"
                };
            }

            try
            {   
                //Main configuration before mapping, contains parameters that makes mapping more flexible (ex. skip empty rows etc.)
                var csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = separator,
                    MissingFieldFound = null,
                    HeaderValidated = null,
                    BadDataFound = null,
                    HasHeaderRecord = hasHeader,
                    IgnoreBlankLines = true,
                    ReadingExceptionOccurred = ex =>
                    {                        
                        return ex.Exception.Message.Contains("__empty_line__") ? false : true;
                    }
                };

                using (var stream = new MemoryStream(file))  
                using (var reader = new StreamReader(stream))
                using (var csv = new CsvReader(reader, csvConfiguration))
                {
                    //Here csv helper uses classMap param to decide what type should be output after mapping.
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
