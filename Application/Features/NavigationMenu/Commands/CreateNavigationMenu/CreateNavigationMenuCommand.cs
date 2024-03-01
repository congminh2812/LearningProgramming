using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LearningProgramming.Application.Features.NavigationMenu.Commands.CreateNavigationMenu
{
    public class CreateNavigationMenuCommand : IRequest<Unit>
    {
        public long? ParentId { get; set; }

        public long CreatedBy { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Url { get; set; }

        public string Icon { get; set; }

        public int Position { get; set; }
    }
}
