namespace LexiconLMS.Core.Interfaces
{
    public interface IHttpService
    {
        Task<TData?> GetAsync<TData>(string url);
        Task PostAsync<TData>(string url, TData data);
        Task PutAsync<TData>(string url, TData data);
        Task DeleteAsync(string url);
    }
}
