using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesData.Entities
{
    public class FridgeEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? OwnerName { get; set; }
        public Guid TypeId { get; set; }
        public virtual FridgeTypeEntity FridgeType { get; set; }
    }
}
