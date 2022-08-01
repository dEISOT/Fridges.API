using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgesModel.Request
{
    public class FridgeRequestModel
    {
        public Guid TypeId { get; set; }
        public string Name { get; set; }
        public string? OwnerName { get; set; }

    }
}
