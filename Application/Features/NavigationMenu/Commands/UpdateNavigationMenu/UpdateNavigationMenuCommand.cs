using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LearningProgramming.Application.Features.NavigationMenu.Commands.UpdateNavigationMenu
{
    public class UpdateNavigationMenuCommand : IRequest<Unit>
    {
        public long Id { get; set; }

        public long? ParentId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public string Icon { get; set; }

        public int Position { get; set; }
    }
}
