using LearningProgramming.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain
{
    public class Message : BaseEntity
    {
        [Column("user_id")]
        public long UserId { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("unread")]
        public bool Unread { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
    }
}
