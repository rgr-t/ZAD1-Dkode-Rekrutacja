using Microsoft.AspNetCore.Mvc;
using MyApi.Models.Dto;

namespace MyApi.Controllers
{
    public partial class WarehouseController
    {
        /// <summary>
        /// Get supplier data using supplier name as parameter
        /// </summary>
        /// <param name="supplierName"></param>
        /// <returns></returns>
        [HttpGet("get/{supplierName}")]
        public async Task<IActionResult> GetWithSupplierName([FromRoute] string supplierName)
        {
            try
            {
                var result = await _warehouseRepository.GetWithSupplierName<SupplierDataDto>(supplierName);

                return Ok(result.Data);
            }
            catch(Exception ex)
            {
                return Ok();
            }
        }
    }
}