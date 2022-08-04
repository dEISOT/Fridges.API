using AutoMapper;
using FridgesCore.Domain;
using FridgesCore.Interfaces;
using FridgesModel.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FridgesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public AuthenticationController(IAuthenticationService authenticationService, IMapper mapper, IUserService userService)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
            _userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _userService.GetByEmailAsync(request.Email);
                if(existingUser is null)
                {
                    var model = _mapper.Map<User>(request);
                    var result = _userService.AddUserAsync(model);
                    return Ok(result);
                }

            }
            return BadRequest();
        }
    }
}
