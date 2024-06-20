using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Core.Repository
{
    public interface IUnitOfWork<TContext> where TContext : DbContext
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
    }
}