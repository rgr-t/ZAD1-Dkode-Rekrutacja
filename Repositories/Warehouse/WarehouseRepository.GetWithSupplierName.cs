using Dapper;
using MyApi.Models.Results.Repository;
using System.Data;

namespace MyApi.Repositories.Warehouse
{
    public partial class WarehouseRepository
    {
        public async Task<GetResult<SupplierDataDto>> GetWithSupplierName<SupplierDataDto>(string supplierName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@supplierName", supplierName);

            try
            {
                var result = await _databaseService.QueryAsync<SupplierDataDto>("dbo.get_with_supplier_name", parameters, CommandType.StoredProcedure);

                return new GetResult<SupplierDataDto>()
                {
                    Success = true,
                    Message = $"Successfully got supplier data with {supplierName} parameter.",
                    Data = result.ToList()
                };
            }
            catch(Exception ex)
            {
                return new GetResult<SupplierDataDto>
                {
                    Success = false,
                    Message = $"Failed to load supplier data with {supplierName} parameter."
                };
            }
        }
    }
}