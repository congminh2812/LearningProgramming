using AutoMapper;
using LearningProgramming.Application.Features.NavigationMenu.Queries;
using LearningProgramming.Domain;

namespace LearningProgramming.Application.MappingProfiles
{
    public class NavigationMenuProfile : Profile
    {
        public NavigationMenuProfile()
        {
            CreateMap<NavigationMenuDto, NavigationMenu>().ReverseMap();
        }
    }
}
