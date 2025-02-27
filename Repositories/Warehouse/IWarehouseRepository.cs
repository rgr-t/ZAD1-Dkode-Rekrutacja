using MyApi.Models.Results.Repository;

namespace MyApi.Repositories.Warehouse
{
    public interface IWarehouseRepository
    {
        Task<GetResult<T>> GetWithSupplierName<T>(string supplierName);
    }
}