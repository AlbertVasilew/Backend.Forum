namespace Domain
{
    public class TaskItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedOn { get; set; }

        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        public required string UserId { get; set; }
    }
}