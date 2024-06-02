using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Tasks.Queries.GetMenuCounters
{
    public class GetMenuCountersHandler : IRequestHandler<GetMenuCountersRequest, MenuCounterDto>
    {
        private readonly ITaskItemRepository taskItemRepository;

        public GetMenuCountersHandler(ITaskItemRepository taskItemRepository)
        {
            this.taskItemRepository = taskItemRepository;
        }

        public async Task<MenuCounterDto> Handle(GetMenuCountersRequest request, CancellationToken cancellationToken)
        {
            return new MenuCounterDto
            {
                Upcoming = await taskItemRepository.GetUpcomingCount(),
                Today = await taskItemRepository.GetUpcomingTodayCount(),
                Overdue = await taskItemRepository.GetOverdueCount(),
                Completed = await taskItemRepository.GetCompletedCount()
            };
        }
    }
}