using Application.Features.Identity.Interfaces;
using Application.Features.Tasks.Dtos;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Tasks.Queries.GetUpcomingTasks
{
    public class GetUpcomingTasksHandler(
        ITaskItemRepository taskItemRepository,
        IMapper mapper,
        IUserContext userContext) : IRequestHandler<GetUpcomingTasksRequest, List<TaskItemDto>>
    {
        public async Task<List<TaskItemDto>> Handle(GetUpcomingTasksRequest request, CancellationToken cancellationToken)
        {
            var userId = userContext.GetCurrentUser()!.Id;

            var tasks = request.OnlyToday
                ? await taskItemRepository.GetUpcomingToday(request.Timezone, userId)
                : await taskItemRepository.GetUpcoming(request.Timezone, userId);

            return mapper.Map<List<TaskItemDto>>(tasks);
        }
    }
}