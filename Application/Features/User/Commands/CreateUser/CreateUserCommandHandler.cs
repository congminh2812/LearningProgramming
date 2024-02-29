using MediatR;

namespace LearningProgramming.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Unit>
    {
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return Unit.Value;
        }
    }
}
