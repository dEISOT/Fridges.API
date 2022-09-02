using FridgesData.Entities;

namespace FridgesData.Interfaces
{
    public interface ITokenRepository
    {
        Task AddAsync(RefreshTokenEntity refreshToken);
        Task<RefreshTokenEntity> TryGetTokenAsync(string refreshToken);
        Task DeleteAsync(RefreshTokenEntity refreshToken);
    }
}
