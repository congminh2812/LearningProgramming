using Microsoft.AspNetCore.Mvc;

namespace LearningProgramming.API.Models
{
    public class CustomValidationProbemDetails : ProblemDetails
    {
        public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
    }
}
