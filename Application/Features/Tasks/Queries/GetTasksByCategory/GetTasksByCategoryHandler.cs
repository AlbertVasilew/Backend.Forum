using Application.Features.Tasks.Dtos;
using AutoMapper;
using Domain.Interfaces.Repositories;
using MediatR;

namespace Application.Features.Tasks.Queries.GetTasksByCategory
{
    public class GetTasksByCategoryHandler : IRequestHandler<GetTasksByCategoryRequest, List<TaskItemDto>>
    {
        private readonly ITaskItemRepository taskItemRepository;
        private readonly IMapper mapper;

        public GetTasksByCategoryHandler(ITaskItemRepository taskItemRepository, IMapper mapper)
        {
            this.taskItemRepository = taskItemRepository;
            this.mapper = mapper;
        }

        public async Task<List<TaskItemDto>> Handle(GetTasksByCategoryRequest request, CancellationToken cancellationToken)
        {
            var tasks = await taskItemRepository.GetAllByCategory(request.CategoryId);
            return mapper.Map<List<TaskItemDto>>(tasks);
        }
    }
}