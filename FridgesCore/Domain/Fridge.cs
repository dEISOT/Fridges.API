using FridgesData.Entities;

namespace FridgesCore.Domain
{
    public class Fridge
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? OwnerName { get; set; }
        public Guid TypeId { get; set; }
        public virtual FridgeTypeEntity FridgeType { get; set; }
        public virtual ICollection<FridgeProductEntity> FridgeProductEntities { get; set; }
    }
}
