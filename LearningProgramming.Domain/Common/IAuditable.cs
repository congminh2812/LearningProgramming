using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain.Common
{
    public interface IAuditable
    {
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
