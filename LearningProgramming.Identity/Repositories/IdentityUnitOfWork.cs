using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Application.Contracts.Identity;
using LearningProgramming.Identity.DBContext;

namespace LearningProgramming.Identity.Repositories
{
    public class IdentityUnitOfWork(LearningProgrammingIdentityDbContext context) : UnitOfWork<LearningProgrammingIdentityDbContext>(context), IIdentityUnitOfWork
    {
    }
}
