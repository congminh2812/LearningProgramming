using MediatR;

namespace LearningProgramming.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
