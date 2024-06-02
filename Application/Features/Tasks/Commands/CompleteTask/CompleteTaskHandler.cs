using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Tasks.Commands.CompleteTask
{
    public class CompleteTaskHandler : IRequestHandler<CompleteTaskRequest, Unit>
    {
        private readonly ITaskItemRepository taskItemRepository;

        public CompleteTaskHandler(ITaskItemRepository taskItemRepository)
        {
            this.taskItemRepository = taskItemRepository;
        }

        public async Task<Unit> Handle(CompleteTaskRequest request, CancellationToken cancellationToken)
        {
            await taskItemRepository.Complete(request.Id);
            return Unit.Value;
        }
    }
}