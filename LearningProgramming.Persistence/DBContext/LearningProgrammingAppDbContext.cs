using LearningProgramming.Domain;
using LearningProgramming.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace LearningProgramming.Persistence.DBContext
{
    public class LearningProgrammingAppDbContext(DbContextOptions<LearningProgrammingAppDbContext> otions) : DbContext(otions)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonComponent> LessonComponents { get; set; }
        public DbSet<UserProgress> UserProgresses { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(LearningProgrammingAppDbContext).Assembly);
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
