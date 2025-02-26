using MyApi.Repositories.Database;

namespace MyApi.Repositories.Stocks
{
    public partial class StocksRepository : IStocksRepository
    {
        private readonly IDatabaseService _databaseService;
        public StocksRepository(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
    }
}