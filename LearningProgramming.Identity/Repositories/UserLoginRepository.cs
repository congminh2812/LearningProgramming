using LearningProgramming.Application.Contracts.Common;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using LearningProgramming.Domain;
using LearningProgramming.Identity.DBContext;
using Microsoft.EntityFrameworkCore;

namespace LearningProgramming.Identity.Repositories
{
    public class UserLoginRepository(LearningProgrammingIdentityDbContext context) : Repository<UserLogin, LearningProgrammingIdentityDbContext>(context), IUserLoginRepository
    {
        public async Task<UserLogin> GetByRefreshToken(string refreshToken)
        {
            var userLogin = await context.UserLogins
                .Include(x => x.User)
                .FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

            return userLogin;
        }
    }
}
