using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Domain;
using LearningProgramming.Identity.DBContext;

namespace LearningProgramming.Identity.Repositories
{
    public class NavigationMenuRepository(LearningProgrammingIdentityDbContext context) : Repository<NavigationMenu>(context), INavigationMenuRepository
    {
    }
}
