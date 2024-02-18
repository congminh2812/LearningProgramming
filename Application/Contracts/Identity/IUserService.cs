using LearningProgramming.Application.Models.Identity;
using LearningProgramming.Domain;

namespace LearningProgramming.Application.Contracts.Identity
{
    public interface IUserService
    {
        Task<User> FindByEmailAsync(string email);

        SignInResult CheckPasswordSignInAsync(User user, string password);

        Task<List<Role>> GetRolesAsync(User user);
    }
}
