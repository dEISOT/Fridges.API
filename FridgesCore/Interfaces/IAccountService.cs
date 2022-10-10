using FridgesModel.Request;
using FridgesModel.Response;

namespace FridgesCore.Interfaces
{
    public interface IAccountService
    {
        Task<LoginResponse> AuthenticateAsync(LoginRequest request);
        Task<Guid> RegisterAsync(RegisterRequest request);
        Task LogoutAsync(string token);
    }
}
