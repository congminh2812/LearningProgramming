using AutoMapper;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using MediatR;

namespace LearningProgramming.Application.Features.NavigationMenu.Commands.DeleteNavigationMenu
{
    public class DeleteNavigationMenuCommandHandler(IMapper mapper, INavigationMenuRepository navigationMenuRepository) : IRequestHandler<DeleteNavigationMenuCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteNavigationMenuCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
