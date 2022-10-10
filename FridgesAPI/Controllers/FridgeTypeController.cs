using FridgesModel.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FridgesAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class FridgeTypeController : ControllerBase
    {
    //    [HttpPost]
    //    public async Task<IActionResult> AddAsync([FromBody] FridgeTypeRequest model)
    //    {
    //        if (!ModelState.IsValid)
    //            return BadRequest();

    //    }
    }
}
