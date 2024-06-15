using MediatR;

namespace Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public int? CategoryId { get; set; }
    }
}