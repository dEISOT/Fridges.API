using FridgesData.Contexts;
using FridgesData.Entities;
using FridgesData.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FridgesData.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDbContext _db;
        public AccountRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Guid> AddAsync(AccountEntity account)
        {
            await _db.Accounts.AddAsync(account);
            await _db.SaveChangesAsync();
            return account.Id;
        }

        public Task<AccountEntity> FindByEmailAsync(string email)
        {
            var response = _db.Accounts.FirstOrDefaultAsync(a => string.Equals(a.Email, email));
            return response;
        }
    }
}
