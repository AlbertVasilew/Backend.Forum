using MediatR;

namespace Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskRequest, Unit>
    {
        public Task<Unit> Handle(DeleteTaskRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}