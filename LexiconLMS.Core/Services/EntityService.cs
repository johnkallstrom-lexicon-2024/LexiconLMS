using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Exceptions;
using LexiconLMS.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LexiconLMS.Core.Services
{
    public class EntityService<TEntity> : EntityService<TEntity, int> where TEntity : class, IEntity, IEquatable<TEntity>, new()
    {
        public EntityService(DbContext dbContext) : base(dbContext) { }
    }

    public class EntityService<TEntity, TKey> : IService<TEntity, TKey>
        where TEntity : class, IEntity, IEquatable<TEntity>, new()
        where TKey : notnull, IEquatable<TKey>
    {
        private readonly DbContext _dbContext;

        public EntityService(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellation = default)
        {
            try
            {
                cancellation.ThrowIfCancellationRequested();
                return await _dbContext.Set<TEntity>().ToListAsync(cancellation);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new EntityNotFoundException("Failed to retrieve entities.", ex);
            }
        }

        public async Task<TEntity> GetAsync(TKey id, CancellationToken cancellation = default)
        {
            TEntity? entity = null;

            try
            {
                cancellation.ThrowIfCancellationRequested();
                entity = await _dbContext.Set<TEntity>().FindAsync(new object[] { id }, cancellation);
            }
            catch (OperationCanceledException)
            {
                throw;
            }

            if (entity == null)
            {
                throw new EntityNotFoundException($"Entity with ID {id} not found.");
            }

            return entity;
        }

        public async Task CreateAsync(TEntity entity, CancellationToken cancellation = default)
        {
            try
            {
                cancellation.ThrowIfCancellationRequested();
                await _dbContext.Set<TEntity>().AddAsync(entity, cancellation);
                await _dbContext.SaveChangesAsync(cancellation);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new EntityNotFoundException("Failed to create entity.", ex);
            }
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellation = default)
        {
            try
            {
                cancellation.ThrowIfCancellationRequested();
                _dbContext.Set<TEntity>().Update(entity);
                await _dbContext.SaveChangesAsync(cancellation);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new EntityNotFoundException("Failed to update entity.", ex);
            }
        }

        public async Task DeleteAsync(TKey id, CancellationToken cancellation = default)
        {
            try
            {
                cancellation.ThrowIfCancellationRequested();
                var entity = await GetAsync(id, cancellation);
                _dbContext.Set<TEntity>().Remove(entity);
                await _dbContext.SaveChangesAsync(cancellation);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (EntityNotFoundException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new EntityNotFoundException("Failed to delete entity.", ex);
            }
        }

        public async Task<OperationResult> ValidateAsync(TEntity entity, CancellationToken cancellation = default)
        {
            var result = new OperationResult { Success = true };

            if (entity.Id.Equals(default(TKey)))
            {
                result.Success = false;
                result.Errors.Append("Id cannot be the default value.");
            }

            // TODO: Add more validation logic as required

            return await Task.FromResult(result);
        }
    }
}
