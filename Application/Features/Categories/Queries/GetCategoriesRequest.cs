using Application.Features.Categories.Dtos;
using MediatR;

namespace Application.Features.Categories.Queries
{
    public class GetCategoriesRequest : IRequest<List<CategoryDto>>
    {
    }
}