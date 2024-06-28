namespace LexiconLMS.Core.Interfaces
{
    public interface IHttpService
    {
        Task<IEnumerable<TModel>> GetListAsync<TModel>(string url);
        Task<TModel?> GetAsync<TModel>(string url);
        Task PostAsync(string url, object data);
        Task PutAsync(string url, object data);
        Task DeleteAsync(string url);
    }
}
