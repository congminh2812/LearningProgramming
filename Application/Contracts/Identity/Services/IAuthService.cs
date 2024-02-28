using LearningProgramming.Application.Models.Identity;

namespace LearningProgramming.Application.Contracts.Identity.Services
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
        Task<AuthResponse> GetNewAccessToken(string refreshToken);
    }
}
