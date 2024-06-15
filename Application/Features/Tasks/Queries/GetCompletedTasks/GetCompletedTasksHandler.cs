using Application.Features.Identity.Interfaces;
using Application.Features.Tasks.Dtos;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Tasks.Queries.GetCompletedTasks
{
    public class GetCompletedTasksHandler(
        ITaskItemRepository taskItemRepository,
        IMapper mapper,
        IUserContext userContext) : IRequestHandler<GetCompletedTasksRequest, List<TaskItemDto>>
    {
        public async Task<List<TaskItemDto>> Handle(GetCompletedTasksRequest request, CancellationToken cancellationToken)
        {
            var userId = userContext.GetCurrentUser()!.Id;
            return mapper.Map<List<TaskItemDto>>(await taskItemRepository.GetCompleted(userId));
        }
    }
}