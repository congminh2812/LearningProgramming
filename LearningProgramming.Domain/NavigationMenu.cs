using LearningProgramming.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain
{
    [Table(name: "navigation_menus", Schema = "identity-service")]
    public class NavigationMenu : BaseEntity, IAuditable, IDeleteable
    {
        [Column("parent_id")]
        public long? ParentId { get; set; }

        [Column("name"), Required]
        public string Name { get; set; }

        [Column("url"), Required]
        public string Url { get; set; }

        [Column("icon")]
        public string Icon { get; set; }

        [Column("position")]
        public int Position { get; set; }

        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("created_by")]
        public long CreatedBy { get; set; }

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }

        [Column("updated_by")]
        public long? UpdatedBy { get; set; }

        [Column("is_deleted")]
        public bool IsDeleted { get; set; }

        [ForeignKey(nameof(ParentId))]
        public NavigationMenu ParentNavigationMenu { get; set; }

        public List<NavigationMenuRole> NavigationMenuRoles { get; set; }
    }
}
