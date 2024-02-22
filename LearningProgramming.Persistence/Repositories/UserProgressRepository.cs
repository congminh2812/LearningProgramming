using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Domain;
using LearningProgramming.Persistence.DBContext;

namespace LearningProgramming.Persistence.Repositories
{
    public class UserProgressRepository(LearningProgrammingAppDbContext context) : Repository<UserProgress>(context), IUserProgressRepository
    {
    }
}
