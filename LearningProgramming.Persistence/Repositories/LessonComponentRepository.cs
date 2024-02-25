using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Application.Persistence;
using LearningProgramming.Domain;
using LearningProgramming.Persistence.DBContext;

namespace LearningProgramming.Persistence.Repositories
{
    public class LessonComponentRepository(LearningProgrammingAppDbContext context) : Repository<LessonComponent, LearningProgrammingAppDbContext>(context), ILessonComponentRepository
    {
    }
}
