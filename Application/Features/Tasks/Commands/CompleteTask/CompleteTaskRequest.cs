using MediatR;

namespace Application.Features.Tasks.Commands.CompleteTask
{
    public class CompleteTaskRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}