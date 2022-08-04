using FridgesData.Contexts;
using FridgesData.Entities;
using FridgesData.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesData.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }
        public async Task<UserEntity> GetByEmailAsync(string email)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => string.Equals(email, u.Email));
            return user;
        }
    }
}
