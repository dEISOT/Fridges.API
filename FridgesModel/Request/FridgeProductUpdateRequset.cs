using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesModel.Request
{
    public class FridgeProductUpdateRequset
    {
        public Guid FridgeProductId { get; set; }
        public int NewQuantity { get; set; }

    }
}
