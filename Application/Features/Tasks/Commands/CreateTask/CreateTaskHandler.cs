using Application.Features.Identity.Interfaces;
using Domain;
using Domain.Interfaces.Repositories;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskHandler(
        ITaskItemRepository taskItemRepository,
        IUnitOfWork unitOfWork, 
        IUserContext userContext) : IRequestHandler<CreateTaskRequest, Unit>
    {
        public async Task<Unit> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {
                Name = request.Name,
                Deadline = request.Deadline,
                CategoryId = request.CategoryId,
                UserId = userContext.GetCurrentUser()!.Id
            };

            await taskItemRepository.Create(task);
            await unitOfWork.SaveChanges();

            return Unit.Value;
        }
    }
}