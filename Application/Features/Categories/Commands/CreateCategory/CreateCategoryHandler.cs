using Domain;
using Domain.Interfaces.Repositories;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryRequest, Unit>
    {
        private readonly ICategoryRepository categoryRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateCategoryHandler(ICategoryRepository categoryRepository, IUnitOfWork unitOfWork)
        {
            this.categoryRepository = categoryRepository;
            this.unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            await categoryRepository.Create(new Category { Name = request.Name, Color = request.Color });
            await unitOfWork.SaveChanges();
            return Unit.Value;
        }
    }
}