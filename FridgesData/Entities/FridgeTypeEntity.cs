using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FridgesData.Entities
{
    public class FridgeTypeEntity
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int? Year { get; set; }
        [JsonIgnore]
        public virtual ICollection<FridgeEntity> Fridges { get; set; }
    }
}
