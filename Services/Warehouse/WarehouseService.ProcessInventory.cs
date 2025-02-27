using MyApi.Helpers.Csv;
using MyApi.Helpers.Other;
using MyApi.Models.Inventory;
using MyApi.Models.Results;

namespace MyApi.Services.Warehouse
{
    public partial class WarehouseService
    {
        //Inventory process method, base on url downloads inventory .csv file, save it, read, map to dto class and save to database.
        private async Task<Result> ProcessInventory(string url)
        {
            //1. Download file.
            var downloadResult = await _fileService.Download(url);

            if (!downloadResult.Success)
                return ResultGenerate.Fail("Failed to download inventory file.");

            //2. Save file.
            var saveResult = await _fileService.Save(downloadResult.File, Constants.InventoryFileName, Constants.InventoryFileExtension);

            if (!saveResult.Success)
                return ResultGenerate.Fail("Failed to save inventory file.");

            //3. Read file.
            var readResult = await _fileService.Read(Constants.InventoryFileName, Constants.InventoryFileExtension);

            if (!readResult.Success)
                return ResultGenerate.Fail("Failed to read inventory file.");

            //4. Map file from csv data to list of objects.
            var mappingResult = await _csvMapperService.MapFromCsv<Inventory>(readResult.FileContent, new InventoryCSVMap(), true, ",");

            if (!mappingResult.Success)
                return ResultGenerate.Fail("Failed to map inventory CSV.");

            //5. Create list of dto objects.
            var stockItemsDtoList = mappingResult.Data
                .Where(i => i.Shipping.Contains("24h"))
                .Select(DtoMapperHelper.MapStockItem)
                .ToList();

            //6. Merge objects to database.
            var mergeResult = await _stocksRepository.Merge(stockItemsDtoList);

            return mergeResult;
        }
    }
}
