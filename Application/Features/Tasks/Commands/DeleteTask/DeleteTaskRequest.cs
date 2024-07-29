using MediatR;

namespace Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}