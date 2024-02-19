using System.ComponentModel.DataAnnotations;

namespace LearningProgramming.Application.Models.Identity
{
    public class TokenRequest
    {
        [Required]
        public string RefreshToken { get; set; }
    }
}
