using FridgesData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesData.Interfaces
{
    public interface IUserRepository
    {
        Task<UserEntity> GetByEmailAsync(string email);

    }
}
