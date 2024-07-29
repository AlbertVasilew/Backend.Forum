using Application.Features.Tasks.Dtos;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.Tasks.Queries.GetTasksByCategory
{
    public class GetTasksByCategoryRequest : IRequest<List<TaskItemDto>>
    {
        [Required]
        public int CategoryId { get; set; }
    }
}