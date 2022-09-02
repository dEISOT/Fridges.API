using System.Text.Json.Serialization;

namespace FridgesData.Entities
{
    public class AccountEntity
    {
        public AccountEntity()
        {
            RefreshTokens = new List<RefreshTokenEntity>();
        }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        [JsonIgnore]
        public virtual List<FridgeEntity> Fridges { get; set; }
        [JsonIgnore]
        public virtual List<RefreshTokenEntity> RefreshTokens { get; set; }
        public string Role { get; set; }
    }
}
