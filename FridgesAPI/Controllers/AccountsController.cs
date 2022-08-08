using AutoMapper;
using FridgesAPI.Controllers.Base;
using FridgesCore.Interfaces;
using FridgesModel.Request;
using FridgesModel.Response;
using Microsoft.AspNetCore.Mvc;

namespace FridgesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class AccountsController : BaseController
    {
        private readonly IAccountsService _accountsService;
        private readonly IMapper _mapper;


        public AccountsController(IAccountsService accountsService, IMapper mapper)
        {
            _accountsService = accountsService;
            _mapper = mapper;
        }
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _accountsService.AuthenticateAsync(model, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _accountsService.GetByEmailAsync(model.Email);
                if (existingUser is null)
                {
                    var result = await _accountsService.RegisterAsync(model);
                    return Ok(result);
                }
            }
            return BadRequest();
        }
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _accountsService.RefreshToken(refreshToken, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }



        // helper methods

        private void setTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }

        private string ipAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
