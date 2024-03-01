using AutoMapper;
using LearningProgramming.Application.Features.NavigationMenu.Commands.CreateNavigationMenu;
using LearningProgramming.Application.Features.NavigationMenu.Queries.GetNavigationMenus;
using LearningProgramming.Domain;

namespace LearningProgramming.Application.MappingProfiles
{
    public class NavigationMenuProfile : Profile
    {
        public NavigationMenuProfile()
        {
            CreateMap<NavigationMenuDto, NavigationMenu>().ReverseMap();
            CreateMap<CreateNavigationMenuCommand, NavigationMenu>();
        }
    }
}
