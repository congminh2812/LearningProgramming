using LearningProgramming.Application.Extensions;
using LearningProgramming.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningProgramming.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Email)
               .HasConversion(
                   v => v.ToLowerInvariant(), // Convert email to lowercase before validation
                   v => v
               )
               .HasAnnotation("RegularExpression", RegularExpressionManager.GetEmailRegularExpression());

            builder.HasData(
                new List<User>
                {
                    new() {
                        Id = 1,
                        Email = "admin@host.com",
                        FirstName = "Admin",
                        LastName = "Web",
                        Password = PasswordManager.GetMd5Hash("admin"),
                        CreatedAt = DateTime.UtcNow,
                    }
                }
            );
        }
    }
}
