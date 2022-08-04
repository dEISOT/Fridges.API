using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FridgesData.Entities
{
    public class UserCredentialsEntity
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }

        [JsonIgnore]
        public string? Password { get; set; }
        public DateTime Created { get; set; }
    }
}
