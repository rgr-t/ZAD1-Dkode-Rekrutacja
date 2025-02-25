using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    public partial class WarehouseController
    {
        [HttpGet("get/{sku}")]
        public async Task<IActionResult> GetWithSupplierName([FromQuery] string sku)
        {
            try
            {
                return Ok();
            }
            catch(Exception ex)
            {
                return Ok();
            }
        }
    }
}
