using LearningProgramming.Domain;
using LearningProgramming.Domain.Common;
using LearningProgramming.Identity.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LearningProgramming.Identity.DBContext
{
    public class LearningProgrammingIdentityDbContext(DbContextOptions<LearningProgrammingIdentityDbContext> otions) : DbContext(otions)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<NavigationMenu> NavigationMenus { get; set; }
        public DbSet<NavigationMenuRole> NavigationMenuRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRole>().HasKey(nr => new { nr.UserId, nr.RoleId });
            builder.Entity<NavigationMenuRole>().HasKey(nr => new { nr.NavigationMenuId, nr.RoleId });

            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(LearningProgrammingIdentityDbContext).Assembly);
            builder.ApplyConfiguration(new UserConfiguration());
        }

        public override int SaveChanges()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is IAuditable && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entityEntry in entities)
            {
                if (entityEntry.State == EntityState.Added)
                    ((IAuditable)entityEntry.Entity).CreatedAt = DateTime.UtcNow;

                ((IAuditable)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
            }

            return base.SaveChanges();
        }
    }
}
