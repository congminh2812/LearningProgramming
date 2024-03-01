using MediatR;
using System.ComponentModel.DataAnnotations;

namespace LearningProgramming.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Unit>
    {
        [Required, MaxLength(255)]
        [EmailAddress]
        public string Email { get; set; }

        [Required, MaxLength(255)]
        public string Password { get; set; }

        [Required, MaxLength(255)]
        public string FirstName { get; set; }

        [Required, MaxLength(255)]
        public string LastName { get; set; }
    }
}
