using LearningProgramming.Domain;

namespace LearningProgramming.Application.Contracts.Persistence
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<List<Role>> GetRolesAsync(User user);
    }
}
