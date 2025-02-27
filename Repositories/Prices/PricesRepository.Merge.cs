using Dapper;
using MyApi.Models.Dto;
using MyApi.Models.Products;
using MyApi.Models.Results.Repository;
using System.Data;

namespace MyApi.Repositories.Prices
{
    public partial class PricesRepository
    {
        public async Task<MergeResult> Merge(List<PricesDto> prices)
        {
            if (prices == null || !prices.Any())
                return new MergeResult() { Success = false, Message = $"Error before merging prices table, list was null or empty" };

            var pricesTable = new DataTable();
                        
            pricesTable.Columns.Add("sku", typeof(string));            
            pricesTable.Columns.Add("price_after_discount", typeof(decimal));
            pricesTable.Columns.Add("vat", typeof(int));
            pricesTable.Columns.Add("price_after_discount_for_product_logistic_unit", typeof(decimal));         
            
            foreach(var price in prices)
            {
                pricesTable.Rows.Add
                    (                        
                        price.Sku,                        
                        price.PriceAfterDiscount,
                        price.Vat,
                        price.PriceAfterDiscountForProductLogisticUnit
                    );
            }

            var parameters = new DynamicParameters();
            parameters.Add("@pricesParamsTable", pricesTable.AsTableValuedParameter("dbo.price_table_type"));

            try
            {
                var result = await _databaseService.QueryAsync<uint>("dbo.merge_prices", parameters, CommandType.StoredProcedure);

                return new MergeResult()
                {
                    Success = true,
                    Message = result.FirstOrDefault() > 0 ? $"Successfully merged prices table." : $"Data is up to date.",
                    RowsAffected = result.FirstOrDefault()
                };
            }
            catch (Exception ex)
            {
                return new MergeResult()
                {
                    Success = false,
                    Message = $"Failed to merge prices table. Error: {ex.Message}"
                };
            }
        }
    }
}
