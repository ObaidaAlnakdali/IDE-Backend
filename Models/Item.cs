using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace IDE_Backend.Models
{
    public partial class Item
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Category { get; set; } = null!;
        public DateTime? DueDate { get; set; }
        public string Estimate { get; set; } = null!;
        public string? Importance { get; set; }
        [JsonIgnore]
        public virtual Status Status { get; set; } = null!;
        public int StatusId { get; set; }

        [JsonIgnore]
        public virtual User User { get; set; } = null!;
        public int UserId { get; set; }
    }
}
