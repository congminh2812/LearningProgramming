using LearningProgramming.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain
{
    public class Message : BaseEntity
    {
        [Column("receiver_id")]
        public long ReceiverId { get; set; }

        [Column("sender_id")]
        public long SenderId { get; set; }

        [Column("content")]
        public string Content { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        [Column("unread")]
        public bool Unread { get; set; }

        [ForeignKey(nameof(ReceiverId))]
        public User Receiver { get; set; }

        [ForeignKey(nameof(SenderId))]
        public User Sender { get; set; }
    }
}
