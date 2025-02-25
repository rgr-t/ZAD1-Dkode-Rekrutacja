using Microsoft.AspNetCore.Mvc;
using MyApi.Services.Warehouse;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }
    }
}