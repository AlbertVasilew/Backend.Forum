namespace Application.Features.Tasks.Dtos
{
    public class UpdateTaskRequestDto
    {
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public int? CategoryId { get; set; }
    }
}