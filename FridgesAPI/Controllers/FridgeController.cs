using AutoMapper;
using FridgesCore.Domain;
using FridgesCore.Interfaces;
using FridgesData.Entities;
using FridgesModel.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FridgesAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FridgeController : ControllerBase
    {
        private readonly IFridgeService _fridgeService;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public FridgeController(IFridgeService fridgeService, ITokenService tokenService, IMapper mapper)
        {
            _fridgeService = fridgeService;
            _tokenService = tokenService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Get(string AccessToken)
        {
            var claims = _tokenService.DecodeJwtToken(AccessToken);
            var result = await _fridgeService.GetAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] FridgeRequestModel request)
        {
            var model = _mapper.Map<Fridge>(request);
            return Ok(await _fridgeService.AddAsync(model));
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
