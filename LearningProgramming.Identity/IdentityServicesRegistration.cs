using LearningProgramming.Application.Contracts.Identity;
using LearningProgramming.Application.Contracts.Identity.Repositories;
using LearningProgramming.Application.Contracts.Identity.Services;
using LearningProgramming.Application.Models.Identity;
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
                options.EnableSensitiveDataLogging();
            });

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddScoped<IIdentityUnitOfWork, IdentityUnitOfWork>();

            services.AddScoped<IUserLoginRepository, UserLoginRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<INavigationMenuRepository, NavigationMenuRepository>();
            services.AddScoped<INavigationMenuRoleRepository, NavigationMenuRoleRepository>();
            services.AddScoped<IAuthService, AuthService>();

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
