using Application.Features.Tasks.Dtos;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Tasks.Queries.GetUpcomingTasks
{
    public class GetUpcomingTasksHandler : IRequestHandler<GetUpcomingTasksRequest, List<TaskItemDto>>
    {
        private readonly ITaskItemRepository taskItemRepository;
        private readonly IMapper mapper;

        public GetUpcomingTasksHandler(ITaskItemRepository taskItemRepository, IMapper mapper)
        {
            this.taskItemRepository = taskItemRepository;
            this.mapper = mapper;
        }

        public async Task<List<TaskItemDto>> Handle(GetUpcomingTasksRequest request, CancellationToken cancellationToken)
        {
            var tasks = request.OnlyToday
                ? await taskItemRepository.GetUpcomingToday(request.Timezone)
                : await taskItemRepository.GetUpcoming(request.Timezone);

            return mapper.Map<List<TaskItemDto>>(tasks);
        }
    }
}