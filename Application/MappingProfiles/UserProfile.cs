using AutoMapper;
using LearningProgramming.Application.Features.User.Commands.CreateUser;
using LearningProgramming.Application.Features.User.Queries.GetUsers;
using LearningProgramming.Domain;

namespace LearningProgramming.Application.MappingProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<CreateUserCommand, User>();
        }
    }
}
