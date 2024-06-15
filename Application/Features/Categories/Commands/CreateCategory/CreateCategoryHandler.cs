using Application.Features.Identity.Interfaces;
using Domain;
using Domain.Interfaces.Repositories;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryHandler(
        ICategoryRepository categoryRepository,
        IUnitOfWork unitOfWork,
        IUserContext userContext) : IRequestHandler<CreateCategoryRequest, Unit>
    {
        public async Task<Unit> Handle(CreateCategoryRequest request, CancellationToken cancellationToken)
        {
            await categoryRepository.Create(new Category
            {
                Name = request.Name,
                Color = request.Color,
                UserId = userContext.GetCurrentUser()!.Id
            });

            await unitOfWork.SaveChanges();
            return Unit.Value;
        }
    }
}