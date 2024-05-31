using Application.Features.Categories.Dtos;
using AutoMapper;
using Domain;

namespace Application.Features.Categories.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks.Count));
        }
    }
}