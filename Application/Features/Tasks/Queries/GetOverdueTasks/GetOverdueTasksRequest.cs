using Application.Features.Tasks.Dtos;
using MediatR;

namespace Application.Features.Tasks.Queries.GetOverdueTasks
{
    public class GetOverdueTasksRequest : IRequest<List<TaskItemDto>>
    {
    }
}