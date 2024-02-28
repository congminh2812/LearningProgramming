using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Application.Models.Identity;
using LearningProgramming.Domain;

namespace LearningProgramming.Application.Contracts.Identity.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        SignInResult CheckPasswordSignInAsync(User user, string password);
        Task<User> FindByEmailAsync(string email);
    }
}
