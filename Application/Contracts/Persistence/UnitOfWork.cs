using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace LearningProgramming.Application.Persistence
{
    public abstract class UnitOfWork<TContext>(TContext context) : IUnitOfWork where TContext : DbContext
    {
        private bool disposed = false;

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entities = context.ChangeTracker.Entries().Where(x => x.Entity is IAuditable && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entityEntry in entities)
            {
                if (entityEntry.State == EntityState.Added)
                    ((IAuditable)entityEntry.Entity).CreatedAt = DateTime.UtcNow;

                ((IAuditable)entityEntry.Entity).UpdatedAt = DateTime.UtcNow;
            }

            return await context.SaveChangesAsync(cancellationToken);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                    context.Dispose();

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
