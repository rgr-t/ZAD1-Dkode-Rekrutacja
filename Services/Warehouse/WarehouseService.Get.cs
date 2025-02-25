using MyApi.Helpers.AppConfig;
using MyApi.Helpers.Csv;
using MyApi.Helpers.Other;
using MyApi.Models.Products;
using MyApi.Models.Results;
using System.Globalization;

namespace MyApi.Services.Warehouse
{
    public partial class WarehouseService
    {
        public async Task<Result> Get()
        {
            var filesToDownload = AppConfigLoader.LoadFileUrls();
            var productsFileDownloadResult = await _fileService.Download(filesToDownload.Products);

            if (productsFileDownloadResult.Success)
            {
                var productsFileSaveResult = await _fileService.Save(
                    productsFileDownloadResult.File,
                    Constants.ProductsFileName,
                    Constants.ProductsFileExtension
                );

                if (productsFileSaveResult.Success)
                {
                    var productsFileContent = await _fileService.Read(
                        Constants.ProductsFileName,
                        Constants.ProductsFileExtension
                    );

                    if (productsFileContent.Success)
                    {
                        var productsList = await _csvMapperService.MapFromCsv<Products>(productsFileContent.FileContent, new ProductsCSVMap(), true, ";", CultureInfo.InvariantCulture);
                        
                    }
                }
            }

            //var PricesList = await _csvMapperService.MapFromCsv<Prices>(productsFileContent.FileContent, new ProductsCSVMap(), true, ";", new CultureInfo("pl-PL"));
            //var InventoryList = await _csvMapperService.MapFromCsv<Inventories>(productsFileContent.FileContent, new ProductsCSVMap(), true, ";", new CultureInfo("pl-PL"));


            return null;
        }
    }
}
