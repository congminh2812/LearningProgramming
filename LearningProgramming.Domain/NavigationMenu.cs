using LearningProgramming.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain
{
    [Table(name: "navigation_menus", Schema = "identity-service")]
    public class NavigationMenu : BaseEntity, IAuditable
    {
        [Column("name"), Required]
        public string Name { get; set; }

        [Column("url"), Required]
        public string Url { get; set; }

        [Column("icon")]
        public string Icon { get; set; }

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
