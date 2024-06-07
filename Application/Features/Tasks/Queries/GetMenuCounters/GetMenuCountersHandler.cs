using Application.Features.Tasks.Dtos;
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
                Upcoming = await taskItemRepository.GetUpcomingCount(request.Timezone),
                Today = await taskItemRepository.GetUpcomingTodayCount(request.Timezone),
                Overdue = await taskItemRepository.GetOverdueCount(request.Timezone),
                Completed = await taskItemRepository.GetCompletedCount()
            };
        }
    }
}