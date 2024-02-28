using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Domain;

namespace LearningProgramming.Application.Contracts.Identity.Repositories
{
    public interface IUserLoginRepository : IRepository<UserLogin>
    {
        Task<UserLogin> GetByRefreshToken(string refreshToken);
    }
}
