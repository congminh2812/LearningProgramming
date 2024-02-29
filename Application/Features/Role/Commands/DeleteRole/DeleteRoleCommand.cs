using MediatR;

namespace LearningProgramming.Application.Features.Role.Commands.DeleteRole
{
    public class DeleteRoleCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
