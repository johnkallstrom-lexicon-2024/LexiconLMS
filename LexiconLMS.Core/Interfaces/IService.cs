using LexiconLMS.Core.Entities;
using LexiconLMS.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LexiconLMS.Core.Interfaces
{
    public interface IService<TEntity>
        : IService<TEntity, int>
        where TEntity : class, IEntity, IEquatable<TEntity>, new()
    {
    }
    public interface IService<TEntity, TKey>
        where TEntity : class, IEntity, IEquatable<TEntity>, new()
        where TKey : notnull, IEquatable<TKey>
    {
        Task CreateAsync(TEntity entity, CancellationToken cancellation = default);
        Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellation = default);
        Task<TEntity> GetAsync(TKey id, CancellationToken cancellation = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellation = default);
        Task<OperationResult> ValidateAsync(TEntity entity, CancellationToken cancellation = default);
    }
}
