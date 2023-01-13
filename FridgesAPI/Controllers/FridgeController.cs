using AutoMapper;
using FridgesCore.Domain;
using FridgesCore.Interfaces;
using FridgesData.Entities;
using FridgesModel.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FridgesAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FridgeController : BaseController
    {
        private readonly IFridgeService _fridgeService;
        private readonly IMapper _mapper;

        public FridgeController(IFridgeService fridgeService, IMapper mapper)
        {
            _fridgeService = fridgeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] FridgeParameters fridgeParameters)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            var result = await _fridgeService.GetAsync(userId, fridgeParameters);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FridgeRequestModel request)
        {
            var accessToken = Request.Cookies["accessToken"];
            
            var model = _mapper.Map<Fridge>(request);

            var fridgeId = await _fridgeService.AddAsync(model, UserId);
            return Ok(fridgeId);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _fridgeService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
