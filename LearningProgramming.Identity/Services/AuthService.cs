using LearningProgramming.Application.Contracts.Identity;
using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Application.Exceptions;
using LearningProgramming.Application.Models.Identity;
using LearningProgramming.Domain;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LearningProgramming.Identity.Services
{
    public class AuthService(IUserService userService, IOptions<JwtSettings> jwtSettings, IUserLoginRepository userLoginRepository, IUnitOfWork unitOfWork) : IAuthService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings.Value;

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await userService.FindByEmailAsync(request.Email) ?? throw new NotFoundException($"User with {request.Email} not found", request.Email);

            var result = userService.CheckPasswordSignInAsync(user, request.Password);

            if (!result.Succeeded)
                throw new BadRequestException($"Creadentials for '{request.Email} aren't valid.'");

            JwtSecurityToken jwtSecurityToken = await GenerateToken(user);
            var refreshToken = GenerateRefreshToken();
            var now = DateTime.Now;
            var expires = now.AddDays(7);

            var userLogin = new UserLogin { ProviderKey = Guid.NewGuid().ToString(), LoginTime = now, ExpiresTime = expires, RefreshToken = refreshToken, UserId = user.Id };
            if (user.UserLogin is null)
                await userLoginRepository.CreateAsync(userLogin);
            else
                userLoginRepository.Update(userLogin);

            await unitOfWork.SaveChangesAsync();

            var response = new AuthResponse
            {
                Id = user.Id,
                Email = user.Email,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                RefreshToken = refreshToken,
            };

            return response;
        }

        public Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            throw new NotImplementedException();
        }

        private async Task<JwtSecurityToken> GenerateToken(User user)
        {
            var roles = await userService.GetRolesAsync(user);
            var roleClaims = roles.Select(s => new Claim(ClaimTypes.Role, s.Id.ToString())).ToList();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            }.Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        private static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
