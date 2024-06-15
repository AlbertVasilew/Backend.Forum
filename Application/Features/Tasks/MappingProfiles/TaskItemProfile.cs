using Application.Features.Tasks.Dtos;
using AutoMapper;
using Domain;

namespace Application.Features.Tasks.MappingProfiles
{
    public class TaskItemProfile : Profile
    {
        public TaskItemProfile()
        {
            CreateMap<TaskItem, TaskItemDto>();
            CreateMap<TaskItemDto, TaskItem>();
        }
    }
}