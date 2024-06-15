using Application.Features.Categories.Dtos;
using Application.Features.Identity.Interfaces;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Categories.Queries
{
    public class GetCategoriesHandler(
        ICategoryRepository categoryRepository,
        IMapper mapper,
        IUserContext userContext) : IRequestHandler<GetCategoriesRequest, List<CategoryDto>>
    {
        public async Task<List<CategoryDto>> Handle(GetCategoriesRequest request, CancellationToken cancellationToken)
        {
            var userId = userContext.GetCurrentUser()!.Id;
            return mapper.Map<List<CategoryDto>>(await categoryRepository.GetAll(userId));
        }
    }
}