using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Persistence.DBContext;

namespace LearningProgramming.Identity.Repositories
{
    public class PersistenceUnitOfWork(LearningProgrammingAppDbContext context) : UnitOfWork<LearningProgrammingAppDbContext>(context), IPersistenceUnitOfWork
    {
    }
}
