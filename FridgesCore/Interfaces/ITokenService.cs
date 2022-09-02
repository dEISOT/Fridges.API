using FridgesData.Entities;
using FridgesModel.Response;

namespace FridgesCore.Interfaces
{
    public interface ITokenService
    {
        Task<LoginResponse> GenerateTokensAsync(AccountEntity account);
        Task<LoginResponse> RefreshTokenAsync(string refrshToken, string accessToken, DateTime time);
    }
}
