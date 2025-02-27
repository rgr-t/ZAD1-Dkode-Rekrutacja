using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace MyApi.Controllers
{
    public partial class WarehouseController
    {
        [HttpGet("get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _warehouseService.Get();

                if (!result.Success)                
                    return BadRequest(new { result.Message });                

                return Ok(result.Message);
            }
            catch (Exception ex)
            {                
                return StatusCode((int)HttpStatusCode.InternalServerError, new { Message = "An unexpected error occurred", Details = ex.Message });
            }
        }
    }
}