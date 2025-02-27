using MyApi.Repositories.Database;

namespace MyApi.Repositories.Warehouse
{
    public partial class WarehouseRepository : IWarehouseRepository
    {
        private readonly IDatabaseService _databaseService;
        public WarehouseRepository(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
    }
}