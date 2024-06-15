using Application.Features.Identity.Interfaces;
using Application.Features.Tasks.Dtos;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Tasks.Queries.GetOverdueTasks
{
    public class GetOverdueTasksHandler(
        ITaskItemRepository taskItemRepository,
        IMapper mapper,
        IUserContext userContext) : IRequestHandler<GetOverdueTasksRequest, List<TaskItemDto>>
    {
        public async Task<List<TaskItemDto>> Handle(GetOverdueTasksRequest request, CancellationToken cancellationToken)
        {
            var userId = userContext.GetCurrentUser()!.Id;
            return mapper.Map<List<TaskItemDto>>(await taskItemRepository.GetOverdue(request.Timezone, userId));
        }
    }
}