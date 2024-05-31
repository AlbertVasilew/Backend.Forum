using Application.Features.Categories.Dtos;

namespace Application.Features.Tasks.Dtos
{
    public class TaskItemDto
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedOn { get; set; }

        public List<CategoryDto> Categories { get; set; }
    }
}