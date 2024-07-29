using Application.Features.Tasks.Dtos;
using MediatR;

namespace Application.Features.Tasks.Queries.GetCompletedTasks
{
    public class GetCompletedTasksRequest : IRequest<List<TaskItemDto>>
    {
    }
}