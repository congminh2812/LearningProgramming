using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Application.Contracts.Persistence.Repositories;
using LearningProgramming.Identity.Repositories;
using LearningProgramming.Persistence.DBContext;
using LearningProgramming.Persistence.Repositories;
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

            services.AddScoped<IPersistenceUnitOfWork, PersistenceUnitOfWork>();

            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IChapterRepository, ChapterRepository>();
            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<ILessonComponentRepository, LessonComponentRepository>();
            services.AddScoped<IUserProgressRepository, UserProgressRepository>();

            return services;
        }
    }
}
