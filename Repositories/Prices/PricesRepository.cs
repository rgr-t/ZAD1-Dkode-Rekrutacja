using MyApi.Repositories.Database;

namespace MyApi.Repositories.Prices
{
    public partial class PricesRepository : IPricesRepository
    {
        private readonly IDatabaseService _databaseService;
        public PricesRepository(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
    }
}
