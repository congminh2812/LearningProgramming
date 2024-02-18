using LearningProgramming.Persistence.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace LearningProgramming.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LearningProgrammingAppDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("LearningProgrammingConnectionString"));
            });

            return services;
        }
    }
}
