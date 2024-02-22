using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Domain;
using LearningProgramming.Persistence.DBContext;

namespace LearningProgramming.Persistence.Repositories
{
    public class LessonRepository(LearningProgrammingAppDbContext context) : Repository<Lesson>(context), ILessonRepository
    {
    }
}
