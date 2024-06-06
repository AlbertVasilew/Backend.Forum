using Application.Features.Tasks.Dtos;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Tasks.Queries.GetOverdueTasks
{
    public class GetOverdueTasksHandler : IRequestHandler<GetOverdueTasksRequest, List<TaskItemDto>>
    {
        private readonly ITaskItemRepository taskItemRepository;
        private readonly IMapper mapper;

        public GetOverdueTasksHandler(ITaskItemRepository taskItemRepository, IMapper mapper)
        {
            this.taskItemRepository = taskItemRepository;
            this.mapper = mapper;
        }

        public async Task<List<TaskItemDto>> Handle(GetOverdueTasksRequest request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<TaskItemDto>>(await taskItemRepository.GetOverdue(request.Timezone));
        }
    }
}