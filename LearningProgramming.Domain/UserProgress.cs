using LearningProgramming.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain
{
    [Table(name: "books", Schema = "app-service")]
    public class UserProgress : BaseEntity, IAuditable
    {
        [Column("user_id")]
        public long UserId { get; set; }

        [Column("lesson_id")]
        public long LessonId { get; set; }

        [Column("completed")]
        public bool Completed { get; set; }

        [Column("completed_at")]
        public DateTime? CompletedAt { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by")]
        public long CreatedBy { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by")]
        public long? UpdatedBy { get; set; }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }

        [ForeignKey(nameof(LessonId))]
        public Lesson Lesson { get; set; }
    }
}
