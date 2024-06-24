using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LexiconLMS.Core.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class, IEntity, IEquatable<TEntity>, new()
    {
        private readonly DbContext _dbContext;

        public Service(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(TEntity id)
        {
            return await _dbContext.Set<TEntity>().AsNoTracking().Where(e => e.Id.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TEntity id)
        {
            var entity = await GetByIdAsync(id);
            // TODO: Check if entity is null and throw exception
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<OperationResult> ValidateAsync(TEntity entity)
        {
            var result = new OperationResult { Success = true };

            // Example validation: Check for non-null Id
            if (entity.Id == null)
            {
                result.Success = false;
                result.Errors.Append("Id cannot be null.");
            }

            // TODO: Add more validation logic as required, possibly with the help of attributes

            return await Task.FromResult(result);
        }
    }
}
