using MediatR;

namespace Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryRequest : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}