using FridgesCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FridgeProductController : ControllerBase
    {
        private readonly IFridgeProductService _fridgeProductService;

        public FridgeProductController(IFridgeProductService fridgeProductService)
        {
            _fridgeProductService = fridgeProductService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var reslut = await _fridgeProductService.Get(id);
            return Ok(reslut);
        }
    }
}
