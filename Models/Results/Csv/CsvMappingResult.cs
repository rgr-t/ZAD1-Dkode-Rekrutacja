namespace MyApi.Models.Results.Csv
{
    public class CsvMappingResult<T> : Result
    {
        public IEnumerable<T> Data { get; set; }
    }
}
