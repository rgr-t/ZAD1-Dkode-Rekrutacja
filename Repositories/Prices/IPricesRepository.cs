using MyApi.Models.Dto;
using MyApi.Models.Results.Repository;

namespace MyApi.Repositories.Prices
{
    public interface IPricesRepository
    {
        Task<MergeResult> Merge(List<PricesDto> prices);
    }
}
