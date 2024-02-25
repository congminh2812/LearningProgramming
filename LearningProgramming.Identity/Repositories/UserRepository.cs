﻿using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Application.Extensions;
using LearningProgramming.Application.Models.Identity;
using LearningProgramming.Application.Persistence;
using LearningProgramming.Domain;
using LearningProgramming.Identity.DBContext;
using Microsoft.EntityFrameworkCore;

namespace LearningProgramming.Identity.Repositories
{
    public class UserRepository(LearningProgrammingIdentityDbContext context) : Repository<User, LearningProgrammingIdentityDbContext>(context), IUserRepository
    {
        public SignInResult CheckPasswordSignInAsync(User user, string password)
        {
            var checkPassword = PasswordManager.VerifyMd5Hash(password, user.Password);

            return new SignInResult { Succeeded = checkPassword };
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await context.Users.Include(x => x.UserLogin).FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
