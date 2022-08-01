using FridgesData.Contexts;
using FridgesData.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesData.Repositories
{
    public class FridgeProductRepository : IFridgeProductRepository
    {
        private readonly AppDbContext _db;
        public FridgeProductRepository(AppDbContext db)
        {
            _db = db;
        }


    }
}
