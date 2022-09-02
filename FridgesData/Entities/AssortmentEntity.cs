using System.Text.Json.Serialization;

namespace FridgesData.Entities
{
    public class AssortmentEntity
    {
        public Guid Id { get; set; }
        [JsonIgnore]
        public virtual ProductEntity Product { get; set; }
        public Guid ProductId { get; set; }
        [JsonIgnore]
        public virtual FridgeEntity Fridge { get; set; }
        public Guid FridgeId { get; set; } 
        public int Quantity { get; set; }
    }
}
