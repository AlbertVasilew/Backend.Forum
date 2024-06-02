using Domain;
using Domain.Interfaces.Repositories;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Tasks.Commands.CreateTask
{
    public class CreateTaskHandler : IRequestHandler<CreateTaskRequest, Unit>
    {
        private readonly ITaskItemRepository taskItemRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateTaskHandler(ITaskItemRepository taskItemRepository, ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.taskItemRepository = taskItemRepository;
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateTaskRequest request, CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {
                Name = request.Name,
                Description = request.Description,
                Deadline = request.Deadline
            };

            var category = await categoryRepository.GetById(request.CategoryId);

            task.Categories.Add(category);

            await taskItemRepository.Create(task);
            await unitOfWork.SaveChanges();

            return Unit.Value;
        }
    }
}