using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain
{
    [Table(name: "user_roles", Schema = "identity-service")]
    public class UserRole
    {
        [Key, Column("user_id")]
        public long UserId { get; set; }

        [Key, Column("role_id")]
        public long RoleId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }

    }
}
