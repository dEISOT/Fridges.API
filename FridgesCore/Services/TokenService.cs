﻿using FridgesCore.Interfaces;
using FridgesData.Entities;
using FridgesData.Interfaces;
using FridgesModel.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;   
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FridgesCore.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenRepository _tokenRepository;
        private readonly IAccountRepository _accountRepository;

        public TokenService(IConfiguration configuration, ITokenRepository tokenRepository, IAccountRepository accountRepository)
        {
            _configuration = configuration;
            _tokenRepository = tokenRepository;
            _accountRepository = accountRepository;
        }

        public async Task<LoginResponse> GenerateTokensAsync(AccountEntity account)
        {
            var role = account.Role;
            var claims = new[]
            {
                new Claim(ClaimTypes.Role, role),
                new Claim(ClaimTypes.NameIdentifier, account.Id.ToString())
            };

            ClaimsIdentity identity = new ClaimsIdentity(claims);

          

            //var tokenHandler = new JwtSecurityTokenHandler();
            // Get secret phrase from configuration
            var secret = _configuration.GetValue<string>("JWT:Secret");
            // Get expiration minutes from configuration
            var JwtTokenExpiration = double.Parse(_configuration.GetValue<string>("JWT:JwtTokenExpirationMinutes"));
            // Encode secrets
            var key = Encoding.UTF8.GetBytes(secret);
            // Set JWT description using user id and user role
            /*var JwtToken = new JwtSecurityToken(
                _configuration.GetValue<string>("JWT:Issuer"),
                _configuration.GetValue<string>("JWT:Audience"),
                expires: DateTime.UtcNow.AddMinutes(JwtTokenExpiration),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
                );
            */
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _configuration.GetValue<string>("JWT:Audience"),
                Issuer = _configuration.GetValue<string>("JWT:Issuer"),
                Subject = identity,
                Expires = DateTime.UtcNow.AddMinutes(JwtTokenExpiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var accessTokenRaw = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(accessTokenRaw);

            var refreshToken = new RefreshTokenEntity
            {
                Token = GenerateRefreshTokenString(),
                ExpireAt = DateTime.UtcNow.AddMinutes(double.Parse(_configuration.GetValue<string>("JWT:RefreshTokenExpirationMinutes"))),
                AccountId = account.Id
            };
            await _tokenRepository.AddAsync(refreshToken);

            var response = new LoginResponse()
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken.Token,
            };
            return response;
        }

        private static string GenerateRefreshTokenString()
        {
            var randomNumber = new byte[32];
            using var randomNumberGenerator = RandomNumberGenerator.Create();
            randomNumberGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public ClaimsPrincipal DecodeJwtToken(string token)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(token))
                {
                    throw new SecurityTokenException("Invalid token");
                }
                var key = Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Secret"));
                var tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken jwtToken;
                var principal = tokenHandler.ValidateToken(token, new TokenValidationParameters()
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidateLifetime = false,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = _configuration["Jwt:Issuer"],
                    ValidAudience = _configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]))
                }, out jwtToken);
                return (principal);
            }
            catch (Exception ex)
            {
                throw;
            }


        }

        public async Task<LoginResponse> RefreshTokenAsync(string refreshToken, string accessToken, DateTime now)
        {
            
            var principal= DecodeJwtToken(accessToken);
            var claims = principal.Claims.ToArray();
            RefreshTokenEntity existingRefreshToken = await _tokenRepository.TryGetTokenAsync(refreshToken);
            if (existingRefreshToken == null)
            {
                throw new SecurityTokenException("Invalid token");
            }
            var claimsId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            var id = new Guid(claimsId);
            var account = await _accountRepository.FindByIdAsync(id);

            if (existingRefreshToken.ExpireAt < now)
            {
                await _tokenRepository.DeleteAsync(existingRefreshToken);
                throw new SecurityTokenException("Invalid token");
            }


            var result = await GenerateTokensAsync(account);

            await _tokenRepository.DeleteAsync(existingRefreshToken);

            return result;
        }
    }
}
