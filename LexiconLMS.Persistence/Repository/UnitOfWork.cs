using LexiconLMS.Core.Exceptions;
using LexiconLMS.Core.Repository;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Persistence.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IRepository<TEntity>? GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.ContainsKey(typeof(TEntity)))
            {
                return (IRepository<TEntity>)_repositories[typeof(TEntity)];
            }

            IRepository<TEntity>? repository = null;
            try
            {
                repository = new Repository<TEntity>(_context);
            }
            catch (RepositoryNotFoundException)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }

            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
