using Dapper;
using MyApi.Models.Dto;
using MyApi.Models.Results.Repository;
using System.Data;

namespace MyApi.Repositories.Products
{
    public partial class ProductsRepository
    {
        public async Task<MergeResult> Merge(List<ProductDto> products)
        {
            if (products == null || !products.Any())
                return new MergeResult() { Success = false, Message = $"Error before merging products table, list was null or empty" };

            var productsTable = new DataTable();

            productsTable.Columns.Add("id", typeof(int));
            productsTable.Columns.Add("sku", typeof(string));
            productsTable.Columns.Add("producer_name", typeof(string));
            productsTable.Columns.Add("main_category", typeof(string));
            productsTable.Columns.Add("sub_category", typeof(string));
            productsTable.Columns.Add("is_vendor", typeof(bool));            

            foreach(var product in products)
            {
                productsTable.Rows.Add
                    (
                        product.Id,
                        product.Sku,
                        product.ProducerName,
                        product.MainCategory,
                        product.SubCategory,
                        product.IsVendor                        
                    );
            }

            var parameters = new DynamicParameters();
            parameters.Add("@productsParamTable", productsTable.AsTableValuedParameter("dbo.product_table_type"));

            try
            {
                var result = await _databaseService.QueryAsync<uint>("dbo.merge_products", parameters, CommandType.StoredProcedure);

                return new MergeResult()
                {
                    Success = true,
                    Message = result.FirstOrDefault() > 0 ? $"Successfully merged products table." : $"Data is up to date.",
                    RowsAffected = result.FirstOrDefault()
                };
            }
            catch(Exception ex)
            {
                return new MergeResult()
                {
                    Success = false,
                    Message = $"Failed to merge products table. Error: {ex.Message}"
                };
            }
        }
    }
}