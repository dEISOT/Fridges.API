using FridgesCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesCore.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByEmailAsync(string email);
        Task<User> AddAsync(User user);
    }
}
