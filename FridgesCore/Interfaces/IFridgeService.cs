using FridgesCore.Domain;
using FridgesData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesCore.Interfaces
{
    public interface IFridgeService
    {
        Task<IEnumerable<FridgeEntity>> GetAsync();
        Task<Guid> AddAsync(Fridge fridge);
        Task DeleteAsync(Guid id);
    }
}
