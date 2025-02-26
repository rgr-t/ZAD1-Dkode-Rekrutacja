using MyApi.Models.Dto;
using MyApi.Models.Results.Repository;

namespace MyApi.Repositories.Stocks
{
    public interface IStocksRepository
    {
        Task<MergeResult> Merge(List<StockItemDto> stocks);
    }
}
