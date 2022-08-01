using FridgesData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesData.Interfaces
{
    public interface IFridgeRepository
    {
        Task<IEnumerable<FridgeEntity>> GetAsync();
        Task<Guid> AddAsync(FridgeEntity fridge);
        Task<FridgeEntity> GetById(Guid id);
        Task DeleteAsync(FridgeEntity entity);
    }
}
