namespace LearningProgramming.Application.Models.Identity
{
    public class AuthResponse
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
