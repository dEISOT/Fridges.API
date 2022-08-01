using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesData.Entities
{
    public class FridgeProductEntity
    {
        public Guid Id { get; set; }
        public virtual ProductEntity Product { get; set; }
        public Guid ProductId { get; set; }
        public virtual FridgeEntity Fridge { get; set; }
        public Guid FridgeId { get; set; } 
        public int Quantity { get; set; }
    }
}
