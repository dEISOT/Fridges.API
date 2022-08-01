using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesData.Entities
{
    public class FridgeTypeEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        public virtual ICollection<FridgeEntity> Fridges { get; set; }
    }
}
