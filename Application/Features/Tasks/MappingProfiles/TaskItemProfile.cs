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
                //.ForMember(dest => dest.Categories, opt => opt.MapFrom(src => src.Categories));

            CreateMap<TaskItemDto, TaskItem>();
        }
    }
}