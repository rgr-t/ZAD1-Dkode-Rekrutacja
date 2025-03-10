﻿using Dapper;
using MyApi.Models.Dto;
using MyApi.Models.Results.Repository;
using System.Data;

namespace MyApi.Repositories.Stocks
{
    public partial class StocksRepository
    {
        //Merging stocks dto list with dbo.products table.
        public async Task<MergeResult> Merge(List<StockItemDto> stock)
        {
            if (stock == null || !stock.Any())
                return new MergeResult() { Success = false, Message = $"Error before merging stock table, list was null or empty" };

            var stockTable = new DataTable();
            
            stockTable.Columns.Add("sku", typeof(string));            
            stockTable.Columns.Add("quantity", typeof(decimal));

            foreach(var item in stock)
            {
                stockTable.Rows.Add
                    (                        
                        item.Sku,                        
                        item.Quantity
                    );
            }

            var parameters = new DynamicParameters();
            parameters.Add("@stocksParamsTable", stockTable.AsTableValuedParameter("dbo.stock_table_type"));

            try
            {
                var result = await _databaseService.QueryAsync<uint>("dbo.merge_stocks", parameters, CommandType.StoredProcedure);

                return new MergeResult()
                {
                    Success = true,
                    Message = result.FirstOrDefault() > 0 ? $"Successfully merged stocks table." : $"Data is up to date.",
                    RowsAffected = result.FirstOrDefault()
                };
            }
            catch(Exception ex)
            {
                return new MergeResult()
                {
                    Success = false,
                    Message = $"Failed to merge stocks table. Error: {ex.Message}"
                };
            }
        }
    }
}