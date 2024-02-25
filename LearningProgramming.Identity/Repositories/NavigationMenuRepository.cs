using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Application.Persistence;
using LearningProgramming.Domain;
using LearningProgramming.Identity.DBContext;
using Microsoft.EntityFrameworkCore;

namespace LearningProgramming.Identity.Repositories
{
    public class NavigationMenuRepository(LearningProgrammingIdentityDbContext context) : Repository<NavigationMenu, LearningProgrammingIdentityDbContext>(context), INavigationMenuRepository
    {
        public async Task<List<NavigationMenu>> GetMenusByUserIdAsync(long userId)
        {
            var data = await context.UserRoles
                .Include(x => x.Role).ThenInclude(x => x.NavigationMenuRoles).ThenInclude(x => x.NavigationMenu)
                .Where(x => x.UserId == userId)
                .SelectMany(x => x.Role.NavigationMenuRoles.Select(d => d.NavigationMenu)).ToListAsync();

            return data;
        }
    }
}
