using LearningProgramming.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain
{
    [Table(name: "users", Schema = "identity-service")]
    public class User : BaseEntity, IAuditable, IDeleteable
    {
        [Column("email"), Required, MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Column("password"), Required, MaxLength(255)]
        public string Password { get; set; }

        [Column("first_name"), Required, MaxLength(255)]
        public string FirstName { get; set; }

        [Column("last_name"), Required, MaxLength(255)]
        public string LastName { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        public UserLogin UserLogin { get; set; }

        public List<Message> Messages { get; set; }
    }
}
