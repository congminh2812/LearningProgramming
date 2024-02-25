using LearningProgramming.Domain;

namespace LearningProgramming.Application.Contracts.Persistence
{
    public interface INavigationMenuRepository : IRepository<NavigationMenu>
    {
        Task<List<NavigationMenu>> GetMenusByUserIdAsync(long userId);
    }
}
