using AutoMapper;
using LearningProgramming.Application.Features.Role.Commands.CreateRole;
using LearningProgramming.Application.Features.Role.Queries.GetRoles;
using LearningProgramming.Domain;

namespace LearningProgramming.Application.MappingProfiles
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<CreateRoleCommand, Role>();
        }
    }
}
