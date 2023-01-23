using FridgesCore.Interfaces;
using FridgesModel.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FridgesAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class FridgeTypeController : BaseController
    {
        private readonly IFridgeTypeService _fridgeTypeService;

        public FridgeTypeController(IFridgeTypeService fridgeTypeService)
        {
            _fridgeTypeService = fridgeTypeService;
        }

        [HttpPost("add-fridge-type")]
        public async Task<IActionResult> Add([FromBody] FridgeTypeRequest model)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var result = await _fridgeTypeService.AddAsync(model);
            return Ok(result);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetAll()
        {

        }
    }
}
