using LearningProgramming.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningProgramming.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                new List<UserRole>
                {
                    new() {
                        RoleId = 1,
                        UserId = 1,
                    }
                }
            );
        }
    }
}
