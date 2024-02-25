using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace LearningProgramming.Common
{
    public static class CommonServiceRegistration
    {
        public static IServiceCollection AddCommonServices(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
}
