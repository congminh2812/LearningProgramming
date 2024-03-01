using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LearningProgramming.Application.Features.Role.Commands.UpdateRole
{
    public class UpdateRoleCommand : IRequest<Unit>
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
    }
}
