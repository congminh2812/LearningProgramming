using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using LearningProgramming.Domain;
using LearningProgramming.Identity.DBContext;

namespace LearningProgramming.Identity.Repositories
{
    public class NavigationMenuRoleRepository(LearningProgrammingIdentityDbContext context) : Repository<NavigationMenuRole, LearningProgrammingIdentityDbContext>(context), INavigationMenuRoleRepository
    {
    }
}
