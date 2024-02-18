using LearningProgramming.Application.Contracts.Persistence;
using LearningProgramming.Identity.DBContext;

namespace LearningProgramming.Identity.Repositories
{
    public class UnitOfWork(LearningProgrammingIdentityDbContext context) : IUnitOfWork
    {
        private bool disposed = false;

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }


        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
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
