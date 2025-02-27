using MyApi.Helpers.AppConfig;
using MyApi.Helpers.Csv;
using MyApi.Helpers.Other;
using MyApi.Models.Dto;
using MyApi.Models.Inventory;
using MyApi.Models.Prices;
using MyApi.Models.Products;
using MyApi.Models.Results;
using System;
using System.Globalization;

namespace MyApi.Services.Warehouse
{
    public partial class WarehouseService
    {
        public async Task<Result> Get()
        {
            try
            {
                var filesToDownload = AppConfigLoader.LoadFileUrls();
                //var productsFileDownloadResult = await _fileService.Download(filesToDownload.Products);

                //if (productsFileDownloadResult.Success)
                //{
                //    var productsFileSaveResult = await _fileService.Save(
                //        productsFileDownloadResult.File,
                //        Constants.ProductsFileName,
                //        Constants.ProductsFileExtension
                //    );

                //    if (productsFileSaveResult.Success)
                //    {
                //        var productsFileReadResult = await _fileService.Read(
                //            Constants.ProductsFileName,
                //            Constants.ProductsFileExtension
                //        );

                //        if (productsFileReadResult.Success)
                //        {
                //            var productsMappingResult = await _csvMapperService.MapFromCsv<Product>(productsFileReadResult.FileContent, new ProductsCSVMap(), true, ";", CultureInfo.InvariantCulture);

                //            if (productsMappingResult.Success)
                //            {

                //                var productsDtoList = productsMappingResult.Data
                //                    .Where(p => p.IsWire == false && p.Shipping == "24h")
                //                    .Select(p => new ProductDto
                //                    {
                //                        Id = p.Id,
                //                        Sku = p.Sku,
                //                        Name = p.Name,
                //                        Ean = p.Ean,
                //                        ProducerName = p.ProducerName,
                //                        MainCategory = p.Category?.Split('|').FirstOrDefault(),
                //                        SubCategory = p.Category?.Split('|').ElementAtOrDefault(1),
                //                        ChildCategory = p.Category?.Split('|').ElementAtOrDefault(2),
                //                        Available = p.Available,
                //                        IsVendor = p.IsVendor,
                //                        DefaultImage = p.DefaultImage
                //                    }).ToList();

                //                var productsMergeResult = await _productsRepository.Merge(productsDtoList);

                //                if (productsMergeResult.Success)
                //                {
                //                    var inventoryFileDownloadResult = await _fileService.Download(filesToDownload.Inventory);

                //                    if (inventoryFileDownloadResult.Success)
                //                    {
                //                        var inventoryFileSaveResult = await _fileService.Save(
                //                            inventoryFileDownloadResult.File,
                //                            Constants.InventoryFileName,
                //                            Constants.InventoryFileExtension
                //                            );

                //                        if (inventoryFileSaveResult.Success)
                //                        {
                //                            var inventoryFileReadResult = await _fileService.Read(Constants.InventoryFileName, Constants.InventoryFileExtension);

                //                            if (inventoryFileReadResult.Success)
                //                            {
                //                                var inventoryFileMappingResult = await _csvMapperService.MapFromCsv<Inventory>(inventoryFileReadResult.FileContent, new InventoryCSVMap(), true, ",", CultureInfo.InvariantCulture);

                //                                if (inventoryFileMappingResult.Success)
                //                                {
                //                                    var stockItemsDtoList = inventoryFileMappingResult.Data
                //                                        .Where(i => i.Shipping == "24h")
                //                                        .ToList()
                //                                        .Select(s => new StockItemDto
                //                                        {
                //                                            ProductId = s.ProductId,
                //                                            Sku = s.Sku,
                //                                            Unit = s.Unit,
                //                                            Quantity = TryParseDecimal(s.Quantity),
                //                                            ManufacturerName = s.ManufacturerName,
                //                                            Shipping = s.Shipping,
                //                                            ShippingCost = TryParseDecimal(s.ShippingCost)
                //                                        }).ToList();

                //                                    var stockMergeResult = await _stocksRepository.Merge(stockItemsDtoList);

                //                                    if (stockMergeResult.Success)
                //                                    {
                //                                        var pricesFileDownloadResult = await _fileService.Download(filesToDownload.Prices);

                //                                        if (pricesFileDownloadResult.Success)
                //                                        {
                //                                            var pricesFileSaveResult = await _fileService.Save(
                //                                                productsFileDownloadResult.File,
                //                                                Constants.PricesFileName,
                //                                                Constants.PricesFileExtension
                //                                            );

                //                                            if (pricesFileSaveResult.Success)
                //                                            {
                //                                                var pricesFileReadResult = await _fileService.Read(Constants.PricesFileName, Constants.PricesFileExtension);

                //                                                if (pricesFileReadResult.Success)
                //                                                {
                //                                                    var pricesFileMappingResult = await _csvMapperService.MapFromCsv<Price>(pricesFileReadResult.FileContent, new PricesCSVMap(), false, ",", CultureInfo.InvariantCulture);
                //                                                }
                //                                            }
                //                                        }
                //                                    }
                //                                }
                //                            }
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
                var pricesFileDownloadResult = await _fileService.Download(filesToDownload.Prices);

                if (pricesFileDownloadResult.Success)
                {
                    var pricesFileSaveResult = await _fileService.Save(
                        pricesFileDownloadResult.File,
                        Constants.PricesFileName,
                        Constants.PricesFileExtension
                    );

                    if (pricesFileSaveResult.Success)
                    {
                        var pricesFileReadResult = await _fileService.Read(Constants.PricesFileName, Constants.PricesFileExtension);

                        if (pricesFileReadResult.Success)
                        {
                            var pricesFileMappingResult = await _csvMapperService.MapFromCsv<Price>(pricesFileReadResult.FileContent, new PricesCSVMap(), false, ",", new CultureInfo("pl-PL"));

                            if (pricesFileMappingResult.Success)
                            {
                                var pricesDtoList = pricesFileMappingResult.Data                                    
                                    .ToList()
                                    .Select(p => new PricesDto
                                    {
                                        UniqueId = p.UniqueId,
                                        Sku = p.Sku,
                                        PriceValue = p.PriceValue,
                                        PriceValueAfterDiscount = p.PriceValueAfterDiscount,
                                        Vat = p.Vat,
                                        PriceAfterDiscountForProductLogisticUnit = p.PriceAfterDiscountForProductLogisticUnit
                                    }).ToList();

                                var MergeResult = await _pricesRepository.Merge(pricesDtoList);

                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("TET");
            }

            //var PricesList = await _csvMapperService.MapFromCsv<Prices>(productsFileContent.FileContent, new ProductsCSVMap(), true, ";", new CultureInfo("pl-PL"));
            //var InventoryList = await _csvMapperService.MapFromCsv<Inventories>(productsFileContent.FileContent, new ProductsCSVMap(), true, ";", new CultureInfo("pl-PL"));


            return null;
        }

        private static decimal TryParseDecimal(string input)
        {
            if (decimal.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                return result;

            return 0m;
        }
    }
}