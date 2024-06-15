using MediatR;

namespace Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public int? CategoryId { get; set; }
    }
}