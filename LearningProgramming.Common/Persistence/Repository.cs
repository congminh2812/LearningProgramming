using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Application.Exceptions;
using LearningProgramming.Domain.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LearningProgramming.Common.Persistence
{
    public abstract class Repository<TEntity, TContext>(TContext context) : IRepository<TEntity> where TEntity : class where TContext : DbContext
    {
        public async Task CreateAsync(TEntity entity)
        {
            await context.AddAsync(entity);
        }

        public async Task Delete(long id)
        {
            var entity = await GetByIdAsync(id) ?? throw new NotFoundException(nameof(TEntity), id);
            Delete(entity);
        }

        public void Delete(TEntity entity)
        {
            if (typeof(TEntity).GetInterfaces().Contains(typeof(IDeleteable)))
            {
                ((IDeleteable)entity).IsDeleted = true;
                Update(entity);
            }

            context.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var query = GetAll();

            if (propertySelectors is not null)
                foreach (var propertySelector in propertySelectors)
                    query = query.Include(propertySelector);

            return query;
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            return GetAll(propertySelectors).Where(predicate);
        }

        public async Task<TEntity> GetByIdAsync(long id) => await context.FindAsync<TEntity>(id);

        public void Update(TEntity entity)
        {
            context.Update(entity);
        }
    }
}
