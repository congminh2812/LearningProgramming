using LearningProgramming.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain
{
    [Table(name: "lesson_components", Schema = "app-service")]
    public class LessonComponent : BaseEntity, IAuditable, IDeleteable
    {
        [Column("lesson_id"), Required]
        public long LessonId { get; set; }

        [Column("component_type"), Required]
        public string ComponentType { get; set; }

        [Column("content")]
        public string Content { get; set; }

        // Order of component within the lesson
        [Column("position"), Required]
        public int Position { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by")]
        public long CreatedBy { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by")]
        public long? UpdatedBy { get; set; }

        [ForeignKey(nameof(LessonId))]
        public Lesson Lesson { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }
    }
}