using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LearningProgramming.Application.Features.Role.Commands.CreateRole
{
    public class CreateRoleCommand : IRequest<Unit>
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public long CreatedBy { get; set; }

    }
}
