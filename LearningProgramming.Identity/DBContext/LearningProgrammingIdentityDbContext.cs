using LearningProgramming.Domain;
using LearningProgramming.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace LearningProgramming.Identity.DBContext
{
    public class LearningProgrammingIdentityDbContext(DbContextOptions<LearningProgrammingIdentityDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<NavigationMenu> NavigationMenus { get; set; }
        public DbSet<NavigationMenuRole> NavigationMenuRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserRole>().HasKey(nr => new { nr.UserId, nr.RoleId });
            builder.Entity<NavigationMenuRole>().HasKey(nr => new { nr.NavigationMenuId, nr.RoleId });

            builder.ApplyConfigurationsFromAssembly(typeof(LearningProgrammingIdentityDbContext).Assembly);
            //builder.ApplyConfiguration(new UserConfiguration());

            base.OnModelCreating(builder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is IAuditable && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entityEntry in entities)
            {
                if (entityEntry.State == EntityState.Added)
                    ((IAuditable)entityEntry.Entity).CreatedAt = DateTime.UtcNow;

                ((IAuditable)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
