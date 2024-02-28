using System.Linq.Expressions;

namespace LearningProgramming.Application.Contracts.Common
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] propertySelectors);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] propertySelectors);
        Task<T> GetByIdAsync(long id);
        Task CreateAsync(T entity);
        void Update(T entity);
        Task Delete(long id);
        void Delete(T entity);
    }
}
