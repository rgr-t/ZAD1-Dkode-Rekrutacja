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
            var productsTable = new DataTable();

            productsTable.Columns.Add("id", typeof(int));
            productsTable.Columns.Add("sku", typeof(string));
            productsTable.Columns.Add("name", typeof(string));
            productsTable.Columns.Add("ean", typeof(string));
            productsTable.Columns.Add("producer_name", typeof(string));
            productsTable.Columns.Add("main_category", typeof(string));
            productsTable.Columns.Add("sub_category", typeof(string));
            productsTable.Columns.Add("child_category", typeof(string));
            productsTable.Columns.Add("available", typeof(bool));
            productsTable.Columns.Add("is_vendor", typeof(bool));
            productsTable.Columns.Add("default_image", typeof(string));

            foreach(var product in products)
            {
                productsTable.Rows.Add
                    (
                        product.Id,
                        product.Sku,
                        product.Name,
                        product.Ean,
                        product.ProducerName,
                        product.MainCategory,
                        product.SubCategory,
                        product.ChildCategory,
                        product.Available,
                        product.IsVendor,
                        product.DefaultImage
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