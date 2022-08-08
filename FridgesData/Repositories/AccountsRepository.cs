using FridgesData.Contexts;
using FridgesData.Entities;
using FridgesData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FridgesData.Repositories
{
    public class AccountsRepository : IAccountsRepository
    {
        private readonly AppDbContext _db;

        public AccountsRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> AddAsync(AccountEntity account)
        {
            _db.Accounts.Add(account);
            await _db.SaveChangesAsync();
            return account.Id;
        }

        public Task Authenticate()
        {
            throw new NotImplementedException();
        }

        public async Task<AccountEntity> GetByEmailAsync(string Email)
        {
            var result = await _db.Accounts.FirstOrDefaultAsync(a => string.Equals(a.Email, Email));
            return result;
        }

        public AccountEntity GetByTokenAsync(string token)
        {
            var account =  _db.Accounts.FirstOrDefault(a => a.RefreshTokens.Any(t => string.Equals(token, t.Token)));
            return account;
        }

        public async Task<bool> IsFirstAccount()
        {
            if (await _db.Accounts.CountAsync() == 0)
                return true;
            else
            { return false; }
        }

        public Task Register()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(AccountEntity account)
        {
            _db.Accounts.Update(account);
            await _db.SaveChangesAsync();
        }
    }
}
