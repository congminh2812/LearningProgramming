using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Domain;
using LearningProgramming.Identity.DBContext;

namespace LearningProgramming.Identity.Repositories
{
    public class NavigationMenuRoleRepository(LearningProgrammingIdentityDbContext context) : Repository<NavigationMenuRole>(context), INavigationMenuRoleRepository
    {
    }
}
