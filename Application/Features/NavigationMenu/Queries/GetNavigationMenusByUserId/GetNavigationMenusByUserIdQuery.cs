using LearningProgramming.Application.Features.NavigationMenu.Queries.GetNavigationMenus;
using MediatR;

namespace LearningProgramming.Application.Features.NavigationMenu.Queries.GetNavigationMenusByUserId
{
    public record GetNavigationMenusByUserIdQuery(long UserId) : IRequest<List<NavigationMenuDto>>
    {

    }
}
