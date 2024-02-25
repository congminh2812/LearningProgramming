
using HRLeaveManagement.Infrastructure.EmailService;
using LearningProgramming.Application.Contracts.Email;
using LearningProgramming.Application.Contracts.Logging;
using LearningProgramming.Application.Models.Email;
using LearningProgramming.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LearningProgramming.Infrastructure

{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            return services;
        }
    }
}