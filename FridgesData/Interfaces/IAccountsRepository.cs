using FridgesData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesData.Interfaces
{
    public interface IAccountsRepository
    {
        Task Authenticate();
        Task Register();
        Task<AccountEntity> GetByEmailAsync(string Email);
        Task UpdateAsync(AccountEntity account);
        Task<bool> IsFirstAccount();
        Task<Guid> AddAsync(AccountEntity account);
        AccountEntity GetByTokenAsync(string token);

    }
}
