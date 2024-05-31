using MediatR;

namespace Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryRequest : IRequest<Unit>
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}