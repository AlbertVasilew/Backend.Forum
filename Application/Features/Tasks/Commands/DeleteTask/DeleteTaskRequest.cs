using MediatR;

namespace Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskRequest : IRequest<Unit>
    {
        public int TaskId { get; set; }
    }
}