using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryRequest, Unit>
    {
        private readonly ICategoryRepository categoryRepository;

        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            await categoryRepository.Update(request.Id, request.Name, request.Color);
            return Unit.Value;
        }
    }
}