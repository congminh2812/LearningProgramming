using MediatR;

namespace LearningProgramming.Application.Features.NavigationMenu.Queries
{
    public record GetNavigationMenusQuery(long UserId) : IRequest<List<NavigationMenuDto>>
    {

    }
}
