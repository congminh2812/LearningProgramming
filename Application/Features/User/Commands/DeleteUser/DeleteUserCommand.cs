using MediatR;

namespace LearningProgramming.Application.Features.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
