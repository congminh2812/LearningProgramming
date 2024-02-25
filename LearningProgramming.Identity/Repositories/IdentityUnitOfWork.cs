using LearningProgramming.Application.Persistence;
using LearningProgramming.Identity.DBContext;

namespace LearningProgramming.Identity.Repositories
{
    public class IdentityUnitOfWork(LearningProgrammingIdentityDbContext context) : UnitOfWork<LearningProgrammingIdentityDbContext>(context)
    {
    }
}
