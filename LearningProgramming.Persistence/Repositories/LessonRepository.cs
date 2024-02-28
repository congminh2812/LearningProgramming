using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Application.Contracts.Persistence.Repositories;
using LearningProgramming.Domain;
using LearningProgramming.Persistence.DBContext;

namespace LearningProgramming.Persistence.Repositories
{
    public class LessonRepository(LearningProgrammingAppDbContext context) : Repository<Lesson, LearningProgrammingAppDbContext>(context), ILessonRepository
    {
    }
}
