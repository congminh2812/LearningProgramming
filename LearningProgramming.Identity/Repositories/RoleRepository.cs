using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using LearningProgramming.Domain;
using LearningProgramming.Identity.DBContext;
using Microsoft.EntityFrameworkCore;

namespace LearningProgramming.Identity.Repositories
{
    public class RoleRepository(LearningProgrammingIdentityDbContext context) : Repository<Role, LearningProgrammingIdentityDbContext>(context), IRoleRepository
    {
        public async Task<List<Role>> GetRolesAsync(User user)
        {
            return await context.UserRoles
                .Where(x => x.UserId == user.Id)
                .Include(x => x.Role)
                .Select(x => x.Role)
                .ToListAsync();
        }
    }
}
