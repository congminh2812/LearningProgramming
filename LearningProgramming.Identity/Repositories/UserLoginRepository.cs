using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Domain;
using LearningProgramming.Identity.DBContext;

namespace LearningProgramming.Identity.Repositories
{
    public class UserLoginRepository(LearningProgrammingIdentityDbContext context) : Repository<UserLogin>(context), IUserLoginRepository
    {
    }
}
