using FridgesData.Entities;
using FridgesModel.Response;
using System.Security.Claims;

namespace FridgesCore.Interfaces
{
    public interface ITokenService
    {
        Task<LoginResponse> GenerateTokensAsync(AccountEntity account);
        Task<LoginResponse> RefreshTokenAsync(string refrshToken, string accessToken, DateTime time);
        ClaimsPrincipal DecodeJwtToken(string token);
    }
}
