using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Domain;

namespace LearningProgramming.Application.Contracts.Identity.Repositories
{
    public interface IRoleRepository : IRepository<Role>
    {
        Task<List<Role>> GetRolesAsync(User user);
    }
}
