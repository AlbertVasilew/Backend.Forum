using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Tasks.Commands.DeleteTask
{
    public class DeleteTaskHandler : IRequestHandler<DeleteTaskRequest, Unit>
    {
        private readonly ITaskItemRepository taskItemRepository;

        public DeleteTaskHandler(ITaskItemRepository taskItemRepository)
        {
            this.taskItemRepository = taskItemRepository;
        }

        public async Task<Unit> Handle(DeleteTaskRequest request, CancellationToken cancellationToken)
        {
            await taskItemRepository.Delete(request.Id);
            return Unit.Value;
        }
    }
}