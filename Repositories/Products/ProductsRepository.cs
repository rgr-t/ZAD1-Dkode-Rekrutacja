using MyApi.Repositories.Database;

namespace MyApi.Repositories.Products
{
    public partial class ProductsRepository : IProductsRepository
    {
        private readonly IDatabaseService _databaseService;
        public ProductsRepository(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
    }
}