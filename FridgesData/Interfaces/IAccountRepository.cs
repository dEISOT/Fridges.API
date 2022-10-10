using FridgesData.Entities;

namespace FridgesData.Interfaces
{
    public interface IAccountRepository
    {
        Task<AccountEntity> FindByEmailAsync(string email);
        Task<Guid> AddAsync(AccountEntity account);
        
    }
}
