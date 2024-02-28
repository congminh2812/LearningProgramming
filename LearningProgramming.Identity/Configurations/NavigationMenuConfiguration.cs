using LearningProgramming.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningProgramming.Identity.Configurations
{
    public class NavigationMenuConfiguration : IEntityTypeConfiguration<NavigationMenu>
    {
        public void Configure(EntityTypeBuilder<NavigationMenu> builder)
        {
            builder.HasData(
                new List<NavigationMenu>
                {
                    new() {
                        Id = 1,
                        Name = "Dashboard",
                        Icon = "dashboard",
                        CreatedBy = 1,
                        CreatedAt = DateTime.UtcNow,
                        Url = "/",
                        Position = 1,
                    },
                    new() {
                        Id = 2,
                        Name = "Users",
                        Icon = "user",
                        CreatedBy = 1,
                        CreatedAt = DateTime.UtcNow,
                        Url = "/users",
                        Position = 2,
                    },
                    new() {
                        Id = 3,
                        Name = "My profile",
                        CreatedBy = 1,
                        CreatedAt = DateTime.UtcNow,
                        Url = "/users/profile",
                        Position = 1,
                        ParentId = 2,
                    },
                    new() {
                        Id = 4,
                        Name = "List of user",
                        CreatedBy = 1,
                        CreatedAt = DateTime.UtcNow,
                        Url = "/users/create",
                        Position = 2,
                        ParentId = 2,
                    },
                    new() {
                        Id = 5,
                        Name = "Roles & permission",
                        CreatedBy = 1,
                        CreatedAt = DateTime.UtcNow,
                        Url = "/users/roles-permission",
                        Position = 3,
                        ParentId = 2,
                    },
                    new() {
                        Id = 6,
                        Name = "Navigation menu",
                        CreatedBy = 1,
                        CreatedAt = DateTime.UtcNow,
                        Url = "/navigation-menu",
                        Position = 3,
                    },
                }
            );
        }
    }
}
