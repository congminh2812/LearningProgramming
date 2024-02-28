using MediatR;

namespace LearningProgramming.Application.Features.NavigationMenu.Queries.GetNavigationMenus
{
    public record GetNavigationMenusQuery(long UserId) : IRequest<List<NavigationMenuDto>>
    {

    }
}
