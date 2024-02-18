using LearningProgramming.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain
{
    [Table(name: "user_logins", Schema = "identity-service")]
    public class UserLogin : BaseEntity
    {
        [Required, Column("user_id")]
        public int UserId { get; set; }

        [Required, Column("provider_key"), MaxLength(36)]
        public string ProviderKey { get; set; }

        [Required, Column("login_time")]
        public DateTime LoginTime { get; set; }

        [Required, Column("expires_time")]
        public DateTime ExpiresTime { get; set; }

        [MaxLength(500), Column("refresh_token")]
        public string RefreshToken { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
