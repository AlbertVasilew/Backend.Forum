using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Tasks.Commands.UpdateTask
{
    public class UpdateTaskRequest : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int? CategoryId { get; set; }
    }

    public class UpdateTaskHandler : IRequestHandler<UpdateTaskRequest, Unit>
    {
        private readonly ITaskItemRepository taskItemRepository;

        public UpdateTaskHandler(ITaskItemRepository taskItemRepository)
        {
            this.taskItemRepository = taskItemRepository;
        }

        public async Task<Unit> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
        {
            await taskItemRepository.Update(request.Id, request.Name, request.Description, request.Deadline, request.CategoryId);
            return Unit.Value;
        }
    }
}