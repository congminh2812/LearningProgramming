using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningProgramming.Domain
{
    [Table(name: "navigation_menu_roles", Schema = "identity-service")]
    public class NavigationMenuRole
    {
        [Key, Column("navigation_menu_id")]
        public int NavigationMenuId { get; set; }

        [Key, Column("role_id")]
        public int RoleId { get; set; }

        [ForeignKey(nameof(NavigationMenuId))]
        public virtual NavigationMenu NavigationMenu { get; set; }

        [ForeignKey(nameof(RoleId))]
        public virtual Role Role { get; set; }
    }
}
