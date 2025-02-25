using MyApi.Models.Results;

namespace MyApi.Services.Warehouse
{
    public interface IWarehouseService
    {
        Task<Result> Get();
        Task<Result> GetWithSupplierName(string sku);
    }
}
