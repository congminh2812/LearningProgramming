using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Domain;
using LearningProgramming.Persistence.DBContext;

namespace LearningProgramming.Persistence.Repositories
{
    public class BookRepository(LearningProgrammingAppDbContext context) : Repository<Book>(context), IBookRepository
    {
    }
}
