using FridgesData.Entities;
using FridgesModel.Request;
using FridgesModel.Response;

namespace FridgesCore.Interfaces
{
    public interface IAccountsService
    {
        Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest model, string ipAddress);
        Task<Guid> RegisterAsync(RegisterRequest model);
        Task<AccountEntity> GetByEmailAsync(string Email);
        Task<AuthenticateResponse> RefreshToken(string token, string ipAddress);
    }
}
