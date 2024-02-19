using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Identity.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LearningProgramming.Identity.Repositories
{
    public class Repository<T>(LearningProgrammingIdentityDbContext context) : IRepository<T> where T : class
    {
        public async Task CreateAsync(T entity)
        {
            await context.AddAsync(entity);
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }

        public IQueryable<T> GetAll(params Expression<Func<T, object>>[] propertySelectors)
        {
            var query = GetAll();

            if (propertySelectors is not null)
                foreach (var propertySelector in propertySelectors)
                    query = query.Include(propertySelector);

            return query;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] propertySelectors)
        {
            return GetAll(propertySelectors).Where(predicate);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.FindAsync<T>(id);
        }

        public void Update(T entity)
        {
            context.Update(entity);
        }
    }
}
