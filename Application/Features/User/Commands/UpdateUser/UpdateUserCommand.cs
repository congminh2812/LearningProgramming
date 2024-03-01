using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LearningProgramming.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public long Id { get; set; }

        [Required, MaxLength(255)]
        public string Password { get; set; }

        [Required, MaxLength(255)]
        public string FirstName { get; set; }

        [Required, MaxLength(255)]
        public string LastName { get; set; }
    }
}
