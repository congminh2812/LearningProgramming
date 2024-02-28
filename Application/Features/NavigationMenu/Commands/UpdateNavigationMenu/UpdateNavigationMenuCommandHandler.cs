using AutoMapper;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using MediatR;

namespace LearningProgramming.Application.Features.NavigationMenu.Commands.UpdateNavigationMenu
{
    public class UpdateNavigationMenuCommandHandler(IMapper mapper, INavigationMenuRepository navigationMenuRepository) : IRequestHandler<UpdateNavigationMenuCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateNavigationMenuCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
