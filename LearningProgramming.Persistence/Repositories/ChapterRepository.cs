using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Domain;
using LearningProgramming.Persistence.DBContext;

namespace LearningProgramming.Persistence.Repositories
{
    public class ChapterRepository(LearningProgrammingAppDbContext context) : Repository<Chapter>(context), IChapterRepository
    {
    }
}
