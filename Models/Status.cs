using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace IDE_Backend.Models
{
    public partial class Status
    {
        public Status()
        {
            Items = new HashSet<Item>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public virtual ICollection<Item> Items { get; set; }

    }
}
