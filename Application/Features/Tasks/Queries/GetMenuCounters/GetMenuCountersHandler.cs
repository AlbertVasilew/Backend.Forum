using Application.Features.Identity.Interfaces;
using Application.Features.Tasks.Dtos;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Tasks.Queries.GetMenuCounters
{
    public class GetMenuCountersHandler(
        ITaskItemRepository taskItemRepository, IUserContext userContext) : IRequestHandler<GetMenuCountersRequest, MenuCounterDto>
    {
        public async Task<MenuCounterDto> Handle(GetMenuCountersRequest request, CancellationToken cancellationToken)
        {
            var userId = userContext.GetCurrentUser()!.Id;

            return new MenuCounterDto
            {
                Upcoming = await taskItemRepository.GetUpcomingCount(request.Timezone, userId),
                Today = await taskItemRepository.GetUpcomingTodayCount(request.Timezone, userId),
                Overdue = await taskItemRepository.GetOverdueCount(request.Timezone, userId),
                Completed = await taskItemRepository.GetCompletedCount(userId)
            };
        }
    }
}