using LearningProgramming.Application.Contracts.Identity;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using LearningProgramming.Application.Exceptions;
using MediatR;

namespace LearningProgramming.Application.Features.NavigationMenu.Commands.UpdateNavigationMenu
{
    public class UpdateNavigationMenuCommandHandler(INavigationMenuRepository navigationMenuRepository, IIdentityUnitOfWork identityUnitOfWork) : IRequestHandler<UpdateNavigationMenuCommand, Unit>
    {
        public async Task<Unit> Handle(UpdateNavigationMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = await navigationMenuRepository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(nameof(Domain.NavigationMenu), request.Id);

            menu.Name = request.Name;
            menu.Url = request.Url;
            menu.Icon = request.Icon;
            menu.Position = request.Position;

            navigationMenuRepository.Update(menu);
            await identityUnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
