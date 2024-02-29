using MediatR;

namespace LearningProgramming.Application.Features.User.Queries.GetUsers
{
    public record GetUsersQuery : IRequest<List<UserDto>>
    {

    }
}
