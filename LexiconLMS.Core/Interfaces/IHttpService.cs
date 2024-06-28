namespace LexiconLMS.Core.Interfaces
{
    public interface IHttpService
    {
        Task<IEnumerable<TModel>> GetListAsync<TModel>(string url);
        Task<TModel?> GetAsync<TModel>(string url);
        Task PostAsync<TModel>(string url, TModel data);
        Task PutAsync<TModel>(string url, TModel data);
        Task DeleteAsync(string url);
    }
}
