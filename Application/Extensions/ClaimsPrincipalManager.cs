using LearningProgramming.Application.Exceptions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LearningProgramming.Application.Extensions
{
    public static class ClaimsPrincipalManager
    {
        public static long GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            var userId = claimsPrincipal.FindFirst(JwtRegisteredClaimNames.Sid)?.Value ??
                throw new NotFoundException("User", "");

            return long.Parse(userId);
        }
    }
}
