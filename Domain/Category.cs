namespace Domain
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Color { get; set; }
        
        public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}