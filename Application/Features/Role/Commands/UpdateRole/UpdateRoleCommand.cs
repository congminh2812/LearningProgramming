using MediatR;

namespace LearningProgramming.Application.Features.Role.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest<Unit>
    {
        public long Id { get; set; }
    }
}
