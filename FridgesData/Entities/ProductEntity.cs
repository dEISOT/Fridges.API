using System.Text.Json.Serialization;

namespace FridgesData.Entities
{
    public class ProductEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? DefaultQuantity { get; set; }
        [JsonIgnore]
        public virtual ICollection<AssortmentEntity> AssortmentEntities { get; set; }
    }
}
