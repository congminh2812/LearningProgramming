using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Domain;
using LearningProgramming.Identity.DBContext;

namespace LearningProgramming.Identity.Repositories
{
    public class UserRoleRepository(LearningProgrammingIdentityDbContext context) : Repository<UserRole>(context), IUserRoleRepository
    {
    }
}
