using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Domain;

namespace LearningProgramming.Application.Contracts.Identity.Repositories
{
    public interface INavigationMenuRepository : IRepository<NavigationMenu>
    {
        Task<List<NavigationMenu>> GetMenusByUserIdAsync(long userId);
    }
}
