using System.Text.Json.Serialization;

namespace FridgesData.Entities
{
    public class RefreshTokenEntity
    {
        public Guid Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpireAt { get; set; }
        public Guid AccountId { get; set; }
        [JsonIgnore]
        public virtual AccountEntity Account { get; set; }
    }
}
