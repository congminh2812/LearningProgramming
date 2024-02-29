using MediatR;

namespace LearningProgramming.Application.Features.Role.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, Unit>
    {
        public async Task<Unit> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
