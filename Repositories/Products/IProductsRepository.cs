using MyApi.Models.Dto;
using MyApi.Models.Results.Repository;

namespace MyApi.Repositories.Products
{
    public interface IProductsRepository
    {
        Task<MergeResult> Merge(List<ProductDto> products);
    }
}