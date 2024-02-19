using LearningProgramming.Application.Contracts.Identity;
using LearningProgramming.Application.Extensions;
using LearningProgramming.Application.Models.Identity;
using LearningProgramming.Domain;
using LearningProgramming.Identity.DBContext;
using Microsoft.EntityFrameworkCore;

namespace LearningProgramming.Identity.Services
{
    public class UserService(LearningProgrammingIdentityDbContext context) : IUserService
    {
        public SignInResult CheckPasswordSignInAsync(User user, string password)
        {
            var checkPassword = PasswordManager.VerifyMd5Hash(password, user.Password);

            return new SignInResult { Succeeded = checkPassword };
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<Role>> GetRolesAsync(User user)
        {
            return await context.UserRoles
                .Where(x => x.UserId == user.Id)
                .Include(x => x.Role)
                .Select(x => x.Role)
                .ToListAsync();
        }
    }
}
