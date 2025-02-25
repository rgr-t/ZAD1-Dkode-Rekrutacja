using MyApi.Services.Csv;
using MyApi.Services.File;

namespace MyApi.Services.Warehouse
{
    public partial class WarehouseService : IWarehouseService
    {
        private readonly IFileService _fileService;
        private readonly ICsvMapperService _csvMapperService;

        public WarehouseService(IFileService fileService, ICsvMapperService csvMapperService)
        {
            _fileService = fileService;
            _csvMapperService = csvMapperService;
        }
    }
}