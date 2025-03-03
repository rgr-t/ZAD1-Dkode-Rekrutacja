using Microsoft.AspNetCore.Mvc;
using MyApi.Models.Dto;

namespace MyApi.Controllers
{
    public partial class WarehouseController
    {
        //Gets desired data using supplier name
        [HttpGet("get/{supplierName}")]
        public async Task<IActionResult> GetWithSupplierName([FromRoute] string supplierName)
        {
            try
            {
                var result = await _warehouseRepository.GetWithSupplierName<SupplierDataDto>(supplierName);

                if (!result.Success)
                    return BadRequest($"{result.Message}");

                return Ok(result.Data);
            }
            catch(Exception ex)
            {
                return BadRequest($"Unexpected error: {ex.Message}");
            }
        }
    }
}