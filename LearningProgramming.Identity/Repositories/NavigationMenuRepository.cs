﻿using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Application.Contracts.Identity.Repositories;
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
                .SelectMany(x => x.Role.NavigationMenuRoles.Select(d => d.NavigationMenu)).Where(x => !x.IsDeleted).ToListAsync();

            return data;
        }
    }
}
