using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, Unit>
    {
        private readonly ICategoryRepository categoryRepository;

        public DeleteCategoryHandler(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            await categoryRepository.Delete(request.Id);
            return Unit.Value;
        }
    }
}