using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Application.Persistence;
using LearningProgramming.Domain;
using LearningProgramming.Identity.DBContext;

namespace LearningProgramming.Identity.Repositories
{
    public class UserRoleRepository(LearningProgrammingIdentityDbContext context) : Repository<UserRole, LearningProgrammingIdentityDbContext>(context), IUserRoleRepository
    {
    }
}
