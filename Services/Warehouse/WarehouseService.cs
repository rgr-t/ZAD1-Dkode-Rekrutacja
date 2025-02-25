using MyApi.Services.Download;

namespace MyApi.Services.Warehouse
{
    public partial class WarehouseService : IWarehouseService
    {
        private readonly IFileService _fileService;
        public WarehouseService(IFileService fileService)
        {
            _fileService = fileService;
        }
    }
}