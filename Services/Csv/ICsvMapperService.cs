using CsvHelper.Configuration;
using MyApi.Models.Results.Csv;
using System.Globalization;

namespace MyApi.Services.Csv
{
    public interface ICsvMapperService
    {
        Task<CsvMappingResult<T>> MapFromCsv<T>(byte[] file, ClassMap<T> classMap, bool hasHeader, string separator); 
    }
}