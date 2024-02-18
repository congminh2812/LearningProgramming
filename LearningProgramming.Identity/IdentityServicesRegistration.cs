using LearningProgramming.Application.Contracts.Identity;
using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Identity.DBContext;
using LearningProgramming.Identity.Repositories;
using LearningProgramming.Identity.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LearningProgramming.Identity
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LearningProgrammingIdentityDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("LearningProgrammingConnectionString"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient<IUserLoginRepository, UserLoginRepository>();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"])),
                };
            });

            return services;
        }
    }
}
