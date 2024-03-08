using LearningProgramming.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain
{
    public class AttachmentMessage : BaseEntity
    {
        [Column("message_id")]
        public long MessageId { get; set; }

        [Column("file_name")]
        public string FileName { get; set; }

        [Column("type")]
        public string Type { get; set; }

        [Column("size")]
        public long Size { get; set; }
    }
}
