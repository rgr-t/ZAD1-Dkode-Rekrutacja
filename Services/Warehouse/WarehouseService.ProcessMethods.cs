using MyApi.Helpers.Csv;
using MyApi.Helpers.Other;
using MyApi.Models.Inventory;
using MyApi.Models.Prices;
using MyApi.Models.Products;
using MyApi.Models.Results;

namespace MyApi.Services.Warehouse
{
    public partial class WarehouseService
    {
        private async Task<Result> ProcessProducts(string url)
        {
            var downloadResult = await _fileService.Download(url);

            if (!downloadResult.Success)
                return ResultGenerate.Fail("Failed to download products file.");

            var saveResult = await _fileService.Save(downloadResult.File, Constants.ProductsFileName, Constants.ProductsFileExtension);

            if (!saveResult.Success)
                return ResultGenerate.Fail("Failed to save products file.");

            var readResult = await _fileService.Read(Constants.ProductsFileName, Constants.ProductsFileExtension);

            if (!readResult.Success)
                return ResultGenerate.Fail("Failed to read products file.");

            var mappingResult = await _csvMapperService.MapFromCsv<Product>(readResult.FileContent, new ProductsCSVMap(), true, ";");

            if (!mappingResult.Success)
                return ResultGenerate.Fail("Failed to map products CSV.");

            var productsDtoList = mappingResult.Data
                .Where(p => p.IsWire == false && p.Shipping.Contains("24h"))
                .Select(DtoMapperHelper.MapProduct)
                .ToList();

            var mergeResult = await _productsRepository.Merge(productsDtoList);

            return mergeResult;
        }

        private async Task<Result> ProcessInventory(string url)
        {
            var downloadResult = await _fileService.Download(url);

            if (!downloadResult.Success)
                return ResultGenerate.Fail("Failed to download inventory file.");

            var saveResult = await _fileService.Save(downloadResult.File, Constants.InventoryFileName, Constants.InventoryFileExtension);

            if (!saveResult.Success)
                return ResultGenerate.Fail("Failed to save inventory file.");

            var readResult = await _fileService.Read(Constants.InventoryFileName, Constants.InventoryFileExtension);

            if (!readResult.Success)
                return ResultGenerate.Fail("Failed to read inventory file.");

            var mappingResult = await _csvMapperService.MapFromCsv<Inventory>(readResult.FileContent, new InventoryCSVMap(), true, ",");

            if (!mappingResult.Success)
                return ResultGenerate.Fail("Failed to map inventory CSV.");

            var stockItemsDtoList = mappingResult.Data
                .Where(i => i.Shipping.Contains("24h"))
                .Select(DtoMapperHelper.MapStockItem)
                .ToList();

            var mergeResult = await _stocksRepository.Merge(stockItemsDtoList);

            return mergeResult;
        }

        private async Task<Result> ProcessPrices(string url)
        {
            var downloadResult = await _fileService.Download(url);

            if (!downloadResult.Success)
                return ResultGenerate.Fail("Failed to download prices file.");

            var saveResult = await _fileService.Save(downloadResult.File, Constants.PricesFileName, Constants.PricesFileExtension);

            if (!saveResult.Success)
                return ResultGenerate.Fail("Failed to save prices file.");

            var readResult = await _fileService.Read(Constants.PricesFileName, Constants.PricesFileExtension);

            if (!readResult.Success)
                return ResultGenerate.Fail("Failed to read prices file.");

            var mappingResult = await _csvMapperService.MapFromCsv<Price>(readResult.FileContent, new PricesCSVMap(), false, ",");

            if (!mappingResult.Success)
                return ResultGenerate.Fail("Failed to map prices CSV.");

            var pricesDtoList = mappingResult.Data.Select(DtoMapperHelper.MapPrice).ToList();

            var mergeResult = await _pricesRepository.Merge(pricesDtoList);

            return mergeResult;
        }
    }
}
