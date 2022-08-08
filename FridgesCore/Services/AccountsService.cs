using AutoMapper;
using FridgesCore.Domain;
using FridgesCore.Interfaces;
using FridgesData.Entities;
using FridgesData.Interfaces;
using FridgesModel.Request;
using FridgesModel.Response;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace FridgesCore.Services
{
    public class AccountsService : IAccountsService
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AccountsService(IAccountsRepository accountsRepository, IMapper mapper, IConfiguration configuration)
        {
            _accountsRepository = accountsRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model, string ipAddress)
        {
            var account = await _accountsRepository.GetByEmailAsync(model.Email);
            var check = BCrypt.Net.BCrypt.Verify(model.Password, account.PasswordHash);
            if (account is null || !check)
            {
                //exception "incorrect email or password"
            }

            var jwtToken = generateJwtToken(account);
            var refreshToken = generateRefreshToken(ipAddress);

            removeOldRefreshTokens(account);

            await _accountsRepository.UpdateAsync(account);

            var response = _mapper.Map<AuthenticateResponse>(account);
            response.JwtToken = jwtToken;
            response.RefreshToken = refreshToken.Token;
            return response;
        }



        public async Task<Guid> RegisterAsync(RegisterRequest model)
        {
            var exist = await _accountsRepository.GetByEmailAsync(model.Email);
            if(exist != null)
            {
                //exception with message "This Email has been already regitered"
            }
            var account = _mapper.Map<AccountEntity>(model);

            // first registered account is an admin

            var isFirstAccount = await _accountsRepository.IsFirstAccount(); /*_context.Accounts.Count() == 0;*/
            account.Role = isFirstAccount ? Role.Admin : Role.User;
            

            account.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

            await _accountsRepository.AddAsync(account);
            return account.Id;
        }

        private string generateJwtToken(AccountEntity account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Get secret phrase from configuration
            var secret = _configuration.GetValue<string>("JWT:Secret");

            // Get expiration minutes from configuration
            var JwtTokenExpiration = double.Parse(_configuration.GetValue<string>("JWT:JwtTokenExpiresMinutes"));

            // Encode secrets
            var key = Encoding.UTF8.GetBytes(secret);

            // Set JWT description using user id and user role
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature),

                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(JwtTokenExpiration),
            };

            // Generate JWT
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // Return serialized JWT in compact format
            return tokenHandler.WriteToken(token);
        }
        private void removeOldRefreshTokens(AccountEntity account)
        {
            account.RefreshTokens.RemoveAll(x =>
                !x.IsActive &&
                x.Created.AddDays(_configuration.GetValue<double>("JWT:RefreshTokenExpiresInDays")) <= DateTime.UtcNow);
        }
        private RefreshTokenEntity generateRefreshToken(string ipAddress)
        {
            using (var rngCryptoServiceProvider = new RNGCryptoServiceProvider())
            {
                var randomBytes = new byte[64];
                rngCryptoServiceProvider.GetBytes(randomBytes);
                var RefreshTokenExpiration = double
                        .Parse(_configuration.GetValue<string>("JWT:RefreshTokenExpiresInDays"));
                return new RefreshTokenEntity
                {
                    Token = Convert.ToBase64String(randomBytes),
                    Expires = DateTime.UtcNow.AddDays(RefreshTokenExpiration),
                    Created = DateTime.UtcNow,
                    CreatedByIp = ipAddress
                };
            }
        }

        public async Task<AccountEntity> GetByEmailAsync(string Email)
        {
            var account = await _accountsRepository.GetByEmailAsync(Email);
            return account;
        }

        public async Task<AuthenticateResponse> RefreshToken(string token, string ipAddress)
        {
            var (refreshToken, account) = getRefreshToken(token);

            // replace old refresh token with a new one and save
            var newRefreshToken = generateRefreshToken(ipAddress);
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            account.RefreshTokens.Add(newRefreshToken);

            removeOldRefreshTokens(account);

            await _accountsRepository.UpdateAsync(account);

            // generate new jwt
            var jwtToken = generateJwtToken(account);

            var response = _mapper.Map<AuthenticateResponse>(account);
            response.JwtToken = jwtToken;
            response.RefreshToken = newRefreshToken.Token;
            return response;
        }
        public async Task RevokeToken(string token, string ipAddress)
        {
            var (refreshToken, account) = getRefreshToken(token);

            // revoke token and save
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.RevokedByIp = ipAddress;
            await _accountsRepository.UpdateAsync(account);
        }
        private (RefreshTokenEntity, AccountEntity) getRefreshToken(string token)
        {
            var account = _accountsRepository.GetByTokenAsync(token);
            if (account == null) { /*exception*/};
            var refreshToken = account.RefreshTokens.FirstOrDefault(x => x.Token == token);
            if (!refreshToken.IsActive) { /*exception*/};
            return (refreshToken, account);
        }
    }
}
