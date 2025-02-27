using MyApi.Helpers.AppConfig;
using MyApi.Models.Results;

namespace MyApi.Services.Warehouse
{
    public partial class WarehouseService
    {
        // Download, save and read files, process files content, save content into database.
        public async Task<Result> Get()
        {
            try
            {
                var filesToDownload = AppConfigLoader.LoadFileUrls();

                // Transaction handling could be applied here.

                var productsResult = await ProcessProducts(filesToDownload.Products);

                if (!productsResult.Success)
                    return productsResult;

                var inventoryResult = await ProcessInventory(filesToDownload.Inventory);

                if (!inventoryResult.Success)
                    return inventoryResult;

                var pricesResult = await ProcessPrices(filesToDownload.Prices);

                if (!pricesResult.Success)
                    return pricesResult;

                return new Result { Success = true, Message = "All files processed successfully." };

            }
            catch(Exception ex)
            {
                return new Result { Success = false, Message = $"Failed to process files. Error: {ex.Message}" };
            }
        }       
    }
}