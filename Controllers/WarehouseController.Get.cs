using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    public partial class WarehouseController
    {
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = _warehouseService.Get();

                return Ok();
            }
            catch(Exception ex)
            {
                return Ok(ex);
            }
        }
    }
}
