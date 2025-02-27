using MyApi.Helpers.Csv;
using MyApi.Helpers.Other;
using MyApi.Models.Products;
using MyApi.Models.Results;

namespace MyApi.Services.Warehouse
{
    public partial class WarehouseService
    {
        //Product process method, base on url downloads products .csv file, save it, read, map to dto class and save to database.
        private async Task<Result> ProcessProducts(string url)
        {
            //1. Download file.
            var downloadResult = await _fileService.Download(url);

            if (!downloadResult.Success)
                return ResultGenerate.Fail("Failed to download products file.");

            //2. Save file.
            var saveResult = await _fileService.Save(downloadResult.File, Constants.ProductsFileName, Constants.ProductsFileExtension);

            if (!saveResult.Success)
                return ResultGenerate.Fail("Failed to save products file.");

            //3. Read file.
            var readResult = await _fileService.Read(Constants.ProductsFileName, Constants.ProductsFileExtension);

            if (!readResult.Success)
                return ResultGenerate.Fail("Failed to read products file.");

            //4. Map file from csv data to list of objects.
            var mappingResult = await _csvMapperService.MapFromCsv<Product>(readResult.FileContent, new ProductsCSVMap(), true, ";");

            if (!mappingResult.Success)
                return ResultGenerate.Fail("Failed to map products CSV.");

            //5. Create list of dto objects.
            var productsDtoList = mappingResult.Data
                .Where(p => p.IsWire == false && p.Shipping.Contains("24h"))
                .Select(DtoMapperHelper.MapProduct)
                .ToList();

            //6. Merge objects to database.
            var mergeResult = await _productsRepository.Merge(productsDtoList);

            return mergeResult;
        }
    }
}
