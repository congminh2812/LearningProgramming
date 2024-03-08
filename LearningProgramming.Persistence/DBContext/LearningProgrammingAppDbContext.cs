using LearningProgramming.Domain;
using Microsoft.EntityFrameworkCore;

namespace LearningProgramming.Persistence.DBContext
{
    public class LearningProgrammingAppDbContext(DbContextOptions<LearningProgrammingAppDbContext> otions) : DbContext(otions)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonComponent> LessonComponents { get; set; }
        public DbSet<UserProgress> UserProgresses { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<AttachmentMessage> AttachmentMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("users", "identity-service", t => t.ExcludeFromMigrations());
            builder.Entity<UserLogin>().ToTable("user_logins", "identity-service", t => t.ExcludeFromMigrations());

            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(LearningProgrammingAppDbContext).Assembly);
        }
    }
}
