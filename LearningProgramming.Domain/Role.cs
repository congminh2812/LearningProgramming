using LearningProgramming.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain
{
    [Table(name: "roles", Schema = "identity-service")]
    public class Role : BaseEntity, IAuditable
    {
        [Column("name")]
        public string Name { get; set; }

        [Column("description")]
        public string Description { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by")]
        public int CreatedBy { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by")]
        public int? UpdatedBy { get; set; }
    }
}
