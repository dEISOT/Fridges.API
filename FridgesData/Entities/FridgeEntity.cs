using System.Text.Json.Serialization;

namespace FridgesData.Entities
{
    public class FridgeEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public string? OwnerName { get; set; }
        public Guid TypeId { get; set; }
        public Guid AccountId { get; set; }
        [JsonIgnore]
        public virtual AccountEntity Account { get; set; }
        [JsonIgnore]
        public virtual FridgeTypeEntity FridgeType { get; set; }
        [JsonIgnore]
        public virtual ICollection<AssortmentEntity> AssortmentEntities { get; set; }
    }
}
