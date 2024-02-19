using LearningProgramming.Domain;

namespace LearningProgramming.Application.Contracts.Persistence
{
    public interface IUserLoginRepository : IRepository<UserLogin>
    {
        Task<UserLogin> GetByRefreshToken(string refreshToken);
    }
}
