using MyApi.Helpers.Csv;
using MyApi.Helpers.Other;
using MyApi.Models.Prices;
using MyApi.Models.Results;

namespace MyApi.Services.Warehouse
{
    public partial class WarehouseService
    {
        //Prices process method, base on url downloads prices .csv file, save it, read, map to dto class and save to database.
        private async Task<Result> ProcessPrices(string url)
        {
            //1. Download file.
            var downloadResult = await _fileService.Download(url);

            if (!downloadResult.Success)
                return ResultGenerate.Fail("Failed to download prices file.");

            //2. Save file.
            var saveResult = await _fileService.Save(downloadResult.File, Constants.PricesFileName, Constants.PricesFileExtension);

            if (!saveResult.Success)
                return ResultGenerate.Fail("Failed to save prices file.");

            //3. Read file.
            var readResult = await _fileService.Read(Constants.PricesFileName, Constants.PricesFileExtension);

            if (!readResult.Success)
                return ResultGenerate.Fail("Failed to read prices file.");

            //4. Map file from csv data to list of objects.
            var mappingResult = await _csvMapperService.MapFromCsv<Price>(readResult.FileContent, new PricesCSVMap(), false, ",");

            if (!mappingResult.Success)
                return ResultGenerate.Fail("Failed to map prices CSV.");

            //5. Create list of dto objects.
            var pricesDtoList = mappingResult.Data.Select(DtoMapperHelper.MapPrice).ToList();

            //6. Merge objects to database.
            var mergeResult = await _pricesRepository.Merge(pricesDtoList);

            return mergeResult;
        }
    }
}