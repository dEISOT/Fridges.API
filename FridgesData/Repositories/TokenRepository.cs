using FridgesData.Contexts;
using FridgesData.Entities;
using FridgesData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FridgesData.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        private readonly AppDbContext _db;

        public TokenRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(RefreshTokenEntity refreshToken)
        {
            _db.RefreshTokens.Add(refreshToken);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(RefreshTokenEntity refreshToken)
        {
            _db.RefreshTokens.Remove(refreshToken);
            await _db.SaveChangesAsync();
        }

        public async Task<RefreshTokenEntity> TryGetTokenAsync(string refreshToken)
        {
            var result = await _db.RefreshTokens.FirstOrDefaultAsync(t => refreshToken.Equals(t.Token));
            return result;
        }
    }
}
