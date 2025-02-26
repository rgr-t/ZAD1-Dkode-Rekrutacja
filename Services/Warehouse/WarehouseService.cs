using MyApi.Repositories.Products;
using MyApi.Repositories.Stocks;
using MyApi.Services.Csv;
using MyApi.Services.File;

namespace MyApi.Services.Warehouse
{
    public partial class WarehouseService : IWarehouseService
    {
        private readonly IFileService _fileService;
        private readonly ICsvMapperService _csvMapperService;
        private readonly IProductsRepository _productsRepository;
        private readonly IStocksRepository _stocksRepository;

        public WarehouseService(
            IFileService fileService,
            ICsvMapperService csvMapperService,
            IProductsRepository productsRepository,
            IStocksRepository stocksRepository
            )
        {
            _fileService = fileService;
            _csvMapperService = csvMapperService;
            _productsRepository = productsRepository;
            _stocksRepository = stocksRepository;
        }
    }
}