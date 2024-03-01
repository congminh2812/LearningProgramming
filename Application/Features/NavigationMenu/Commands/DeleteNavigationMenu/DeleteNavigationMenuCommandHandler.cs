using LearningProgramming.Application.Contracts.Identity;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using LearningProgramming.Application.Exceptions;
using MediatR;

namespace LearningProgramming.Application.Features.NavigationMenu.Commands.DeleteNavigationMenu
{
    public class DeleteNavigationMenuCommandHandler(INavigationMenuRepository navigationMenuRepository, IIdentityUnitOfWork identityUnitOfWork) : IRequestHandler<DeleteNavigationMenuCommand, Unit>
    {
        public async Task<Unit> Handle(DeleteNavigationMenuCommand request, CancellationToken cancellationToken)
        {
            var _ = await navigationMenuRepository.GetByIdAsync(request.Id)
                ?? throw new BadRequestException($"Id: {request.Id} doesn't exist");

            await navigationMenuRepository.Delete(request.Id);
            await identityUnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
