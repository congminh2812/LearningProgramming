using LearningProgramming.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain
{
    [Table(name: "messages", Schema = "app-service")]
    public class Message : BaseEntity, IAuditable
    {
        [Column("receiver_id")]
        public long ReceiverId { get; set; }

        [Column("sender_id")]
        public long SenderId { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("unread")]
        public bool Unread { get; set; }

        [ForeignKey(nameof(ReceiverId))]
        public User Receiver { get; set; }

        [ForeignKey(nameof(SenderId))]
        public User Sender { get; set; }
    }
}
