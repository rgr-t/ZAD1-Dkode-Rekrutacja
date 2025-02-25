using MyApi.Helpers;
using MyApi.Models.Results;

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
            }

            return null;
        }
    }
}
