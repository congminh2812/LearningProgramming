using AutoMapper;
using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Application.Features.LeaveAllocation.Commands.CreateLeaveAllocation;
using MediatR;

namespace LearningProgramming.Application.Features.NavigationMenu.Commands.CreateNavigationMenu
{
    public class CreateNavigationMenuCommandHandler(IMapper mapper, INavigationMenuRepository navigationMenuRepository) : IRequestHandler<CreateNavigationMenuCommand, Unit>
    {
        public async Task<Unit> Handle(CreateNavigationMenuCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
