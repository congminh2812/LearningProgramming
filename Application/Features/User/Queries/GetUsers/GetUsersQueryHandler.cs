using AutoMapper;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using LearningProgramming.Application.Contracts.Logging;
using MediatR;

namespace LearningProgramming.Application.Features.User.Queries.GetUsers
{
    public class GetUsersQueryHandler(IUserRepository roleRepository, IAppLogger<GetUsersQueryHandler> logger, IMapper mapper) : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {

            return new List<UserDto>();
        }
    }
}
