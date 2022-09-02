namespace IDE_Backend
{
    public class ItemDto
    {
        public string Title { get; set; } = "Learning Python";
        public string Category { get; set; } = "Learning";
        public DateTime? DueDate { get; set; }
        public string Estimate { get; set; } = "1 hour";
        public string? Importance { get; set; }
        public int StatusId { get; set; } = 1;
        public int UserId { get; set; } = 3;
    }
}
