using AutoMapper;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using LearningProgramming.Application.Contracts.Logging;
using MediatR;

namespace LearningProgramming.Application.Features.Role.Queries.GetRoles
{
    public class GetRolesQueryHandler(IRoleRepository roleRepository, IAppLogger<GetRolesQueryHandler> logger, IMapper mapper) : IRequestHandler<GetRolesQuery, List<RoleDto>>
    {
        public async Task<List<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
        {

            return new List<RoleDto>();
        }
    }
}
