using LearningProgramming.Application.Models.Identity;
using LearningProgramming.Domain;

namespace LearningProgramming.Application.Contracts.Persistence
{
    public interface IUserRepository : IRepository<User>
    {
        SignInResult CheckPasswordSignInAsync(User user, string password);
        Task<User> FindByEmailAsync(string email);
    }
}
