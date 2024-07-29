using Application.Features.Categories.Dtos;

namespace Application.Features.Tasks.Dtos
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? CompletedOn { get; set; }
        public CategoryDto Category { get; set; }
    }
}