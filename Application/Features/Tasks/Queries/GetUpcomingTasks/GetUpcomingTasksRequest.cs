using Application.Features.Tasks.Dtos;
using MediatR;

namespace Application.Features.Tasks.Queries.GetUpcomingTasks
{
    public class GetUpcomingTasksRequest : IRequest<List<TaskItemDto>>
    {
        public bool OnlyToday { get; set; } = false;
        public string Timezone { get; set; }
    }
}