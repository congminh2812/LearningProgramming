using LearningProgramming.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningProgramming.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new List<Role>
                {
                    new() {
                        Id = 1,
                        Name = "Admin",
                        Description = "Admin management system",
                        CreatedAt = DateTime.UtcNow,
                        CreatedBy = 1
                    }
                }
            );
        }
    }
}
