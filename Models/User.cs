using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IDE_Backend.Models
{
    public partial class User
    {
        public User()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Item> Items { get; set; }
    }
}
