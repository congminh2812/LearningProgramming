using MediatR;

namespace LearningProgramming.Application.Features.NavigationMenu.Queries.GetNavigationMenus
{
    public record GetNavigationMenusQuery : IRequest<List<NavigationMenuDto>>
    {

    }
}
