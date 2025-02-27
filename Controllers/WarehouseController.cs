using Microsoft.AspNetCore.Mvc;
using MyApi.Repositories.Warehouse;
using MyApi.Services.Warehouse;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class WarehouseController : Controller
    {
        private readonly IWarehouseService _warehouseService;
        private readonly IWarehouseRepository _warehouseRepository;

        public WarehouseController(IWarehouseService warehouseService, IWarehouseRepository warehouseRepository)
        {
            _warehouseService = warehouseService;
            _warehouseRepository = warehouseRepository;
        }
    }
}