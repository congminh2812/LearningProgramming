using AutoMapper;
using LearningProgramming.Application.Contracts.Identity;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using MediatR;

namespace LearningProgramming.Application.Features.NavigationMenu.Commands.CreateNavigationMenu
{
    public class CreateNavigationMenuCommandHandler(IMapper mapper, INavigationMenuRepository navigationMenuRepository, IIdentityUnitOfWork identityUnitOfWork) : IRequestHandler<CreateNavigationMenuCommand, Unit>
    {
        public async Task<Unit> Handle(CreateNavigationMenuCommand request, CancellationToken cancellationToken)
        {
            var model = mapper.Map<Domain.NavigationMenu>(request);
            await navigationMenuRepository.CreateAsync(model);
            await identityUnitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
