using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Core.Repository
{
    public interface IUnitOfWork
    {
        IRepository<TEntity>? GetRepository<TEntity>() where TEntity : class;
        Task<int> SaveChangesAsync();
    }
}