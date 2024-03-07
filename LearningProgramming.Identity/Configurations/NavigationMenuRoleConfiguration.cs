using LearningProgramming.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningProgramming.Identity.Configurations
{
    public class NavigationMenuRoleConfiguration : IEntityTypeConfiguration<NavigationMenuRole>
    {
        public void Configure(EntityTypeBuilder<NavigationMenuRole> builder)
        {
            builder.HasData(
                new List<NavigationMenuRole>
                {
                    new() {
                        RoleId = 1,
                        NavigationMenuId = 1
                    },
                     new() {
                        RoleId = 1,
                        NavigationMenuId = 2
                    },
                      new() {
                        RoleId = 1,
                        NavigationMenuId = 3
                    },
                       new() {
                        RoleId = 1,
                        NavigationMenuId = 4
                    },
                        new() {
                        RoleId = 1,
                        NavigationMenuId = 5
                    },
                        new() {
                        RoleId = 1,
                        NavigationMenuId = 6
                    },
                        new() {
                        RoleId = 1,
                        NavigationMenuId = 7
                    },
                }
            );
        }
    }
}
