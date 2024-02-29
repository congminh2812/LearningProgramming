using MediatR;

namespace LearningProgramming.Application.Features.Role.Queries.GetRoles
{
    public record GetRolesQuery : IRequest<List<RoleDto>>
    {

    }
}
