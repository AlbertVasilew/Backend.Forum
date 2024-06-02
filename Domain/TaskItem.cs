namespace Domain
{
    public class TaskItem
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? CompletedOn { get; set; }

        public ICollection<Category> Categories { get; set; } = new List<Category>();
    }
}