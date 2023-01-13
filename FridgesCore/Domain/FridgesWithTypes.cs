using FridgesData.Entities;
using FridgesModel.Response;

namespace FridgesCore.Domain
{
    public class FridgesWithTypes
    {
        public IEnumerable<FridgeResponse> Fridges { get; set; }
        public IEnumerable<FridgeTypeEntity> Types { get; set; }
    }
}
