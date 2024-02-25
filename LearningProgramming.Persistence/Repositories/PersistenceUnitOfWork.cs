using LearningProgramming.Application.Persistence;
using LearningProgramming.Persistence.DBContext;

namespace LearningProgramming.Identity.Repositories
{
    public class PersistenceUnitOfWork(LearningProgrammingAppDbContext context) : UnitOfWork<LearningProgrammingAppDbContext>(context)
    {
    }
}
