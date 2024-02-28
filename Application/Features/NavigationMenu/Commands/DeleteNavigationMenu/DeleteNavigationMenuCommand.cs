using MediatR;

namespace LearningProgramming.Application.Features.NavigationMenu.Commands.DeleteNavigationMenu
{
    public class DeleteNavigationMenuCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
