using LearningProgramming.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain
{
    [Table(name: "books", Schema = "app-service")]
    public class Book : BaseEntity, IAuditable
    {
        [Column("title"), Required, MaxLength(255)]
        public string Title { get; set; }

        [Column("image")]
        public string Image { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by")]
        public int CreatedBy { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by")]
        public int? UpdatedBy { get; set; }

        public List<Chapter> Chapters { get; set; }
    }
}

