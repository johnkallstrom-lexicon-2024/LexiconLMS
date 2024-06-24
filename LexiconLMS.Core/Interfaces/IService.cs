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
            where TEntity : class, IEntity, IEquatable<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(TEntity id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity id);
        Task<OperationResult> ValidateAsync(TEntity entity);
    }
}
