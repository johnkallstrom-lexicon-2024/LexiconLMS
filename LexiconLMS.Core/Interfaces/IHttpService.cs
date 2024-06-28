namespace LexiconLMS.Core.Interfaces
{
    public interface IHttpService<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetListAsync(string url);
        Task<TEntity?> GetAsync(string url);
        Task PostAsync(string url, object data);
        Task PutAsync(string url, object data);
        Task DeleteAsync(string url);
    }
}
