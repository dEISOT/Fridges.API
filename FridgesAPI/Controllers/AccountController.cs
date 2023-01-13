using FridgesCore.Interfaces;
using FridgesModel.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FridgesAPI.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _accountService.AuthenticateAsync(request);

            //HttpContext.Response.Cookies.Append("refreshToken", result.RefreshToken,
            //    new CookieOptions
            //    {
            //        Secure = true,
            //        HttpOnly = true
            //    });

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }
                var jwtResult = await _tokenService.RefreshTokenAsync(request.RefreshToken, request.AccessToken, DateTime.UtcNow);

                return Ok(jwtResult);
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var accountId = await _accountService.RegisterAsync(request);

            return Ok(accountId);

        }
       [AllowAnonymous]
        [HttpGet("logout/{refreshToken}")]
        public async Task<IActionResult> Logout(string refreshToken)
        {
            await _accountService.LogoutAsync(refreshToken);
            return NoContent();
        }
    }
}
