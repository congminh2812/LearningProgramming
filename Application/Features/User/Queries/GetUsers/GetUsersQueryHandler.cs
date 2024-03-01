using AutoMapper;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LearningProgramming.Application.Features.User.Queries.GetUsers
{
    public class GetUsersQueryHandler(IUserRepository userRepository, IMapper mapper) : IRequestHandler<GetUsersQuery, List<UserDto>>
    {
        public async Task<List<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var data = await userRepository.GetAll().ToListAsync(cancellationToken);
            var dataDto = mapper.Map<List<UserDto>>(data);

            return dataDto;
        }
    }
}
