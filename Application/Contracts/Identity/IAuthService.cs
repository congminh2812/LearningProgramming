using LearningProgramming.Application.Models.Identity;

namespace LearningProgramming.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request);
        Task<AuthResponse> RefreshToken(TokenRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
