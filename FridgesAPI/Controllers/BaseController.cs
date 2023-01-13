﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FridgesAPI.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : ControllerBase
    {

        protected Guid UserId => ValidateJwtToken(HttpContext.Request.Headers.Authorization.ToString()) ?? Guid.Empty;
        protected Guid? ValidateJwtToken(string? token)
        {
            if (token is null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("superSecretKey@345");
            token = token.Replace("Bearer ", "");
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidIssuer = "AuthenticateComp",
                    ValidAudience = "AuthDemo",
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

                // return user id from JWT token if validation successful
                return userId;
            }
            catch
            {
                // return null if validation fails
                return null;
            }
        }

    }
}