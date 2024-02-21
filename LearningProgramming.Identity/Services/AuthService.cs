﻿using LearningProgramming.Application.Contracts.Identity;
using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Application.Exceptions;
using LearningProgramming.Application.Extensions;
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
    public class AuthService(IUserRepository userRepository, IOptions<JwtSettings> jwtSettings, IUserLoginRepository userLoginRepository, IRoleRepository roleRepository, IUnitOfWork unitOfWork) : IAuthService
    {
        private readonly JwtSettings _jwtSettings = jwtSettings.Value;

        public async Task<AuthResponse> Login(AuthRequest request)
        {
            var user = await userRepository.FindByEmailAsync(request.Email) ?? throw new NotFoundException($"User with {request.Email} not found", request.Email);

            var result = userRepository.CheckPasswordSignInAsync(user, request.Password);

            if (!result.Succeeded)
                throw new BadRequestException($"Creadentials for '{request.Email} aren't valid.'");

            var accessToken = await GenerateToken(user);
            var refreshToken = GenerateRefreshToken();
            var now = DateTime.UtcNow;
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
                AccessToken = accessToken,
                RefreshToken = refreshToken,
            };

            return response;
        }

        public async Task<AuthResponse> RefreshToken(TokenRequest request)
        {
            var userLogin = await userLoginRepository.GetByRefreshToken(request.RefreshToken);

            if (userLogin is null || userLogin.ExpiresTime <= DateTime.Now)
                return null;

            return new AuthResponse
            {
                Id = userLogin.UserId,
                Email = userLogin.User.Email,
                AccessToken = await GenerateToken(userLogin.User),
                RefreshToken = userLogin.RefreshToken,
            };
        }

        public async Task<RegistrationResponse> Register(RegistrationRequest request)
        {
            var user = await userRepository.FindByEmailAsync(request.Email);
            if (user is not null)
                throw new BadRequestException($"User with {request.Email} existed");

            user = new User { Email = request.Email, FirstName = request.FirstName, LastName = request.LastName, Password = PasswordManager.GetMd5Hash(request.Password) };
            await userRepository.CreateAsync(user);

            await unitOfWork.SaveChangesAsync();

            return new RegistrationResponse { UserId = user.Id };
        }

        private async Task<string> GenerateToken(User user)
        {
            var roles = await roleRepository.GetRolesAsync(user);
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

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }

        private static string GenerateRefreshToken()
        {
            return Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
        }
    }
}
