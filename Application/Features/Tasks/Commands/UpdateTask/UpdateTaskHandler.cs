using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskHandler : IRequestHandler<UpdateTaskRequest, Unit>
    {
        private readonly ITaskItemRepository taskItemRepository;

        public UpdateTaskHandler(ITaskItemRepository taskItemRepository)
        {
            this.taskItemRepository = taskItemRepository;
        }

        public async Task<Unit> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
        {
            await taskItemRepository.Update(request.Id, request.Name, request.Deadline, request.CategoryId);
            return Unit.Value;
        }
    }
}