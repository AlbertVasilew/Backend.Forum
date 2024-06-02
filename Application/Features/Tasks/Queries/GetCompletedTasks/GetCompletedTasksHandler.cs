using Application.Features.Tasks.Dtos;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Tasks.Queries.GetCompletedTasks
{
    public class GetCompletedTasksHandler : IRequestHandler<GetCompletedTasksRequest, List<TaskItemDto>>
    {
        private readonly ITaskItemRepository taskItemRepository;
        private readonly IMapper mapper;

        public GetCompletedTasksHandler(ITaskItemRepository taskItemRepository, IMapper mapper)
        {
            this.taskItemRepository = taskItemRepository;
            this.mapper = mapper;
        }

        public async Task<List<TaskItemDto>> Handle(GetCompletedTasksRequest request, CancellationToken cancellationToken)
        {
            return mapper.Map<List<TaskItemDto>>(await taskItemRepository.GetCompleted());
        }
    }
}