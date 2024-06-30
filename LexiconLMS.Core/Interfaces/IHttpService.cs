namespace LexiconLMS.Core.Interfaces
{
    public interface IHttpService
    {
        Task<TData?> GetAsync<TData>(string url);
        Task PostAsync(string url, object data);
        Task<TValue?> PostAsync<TValue>(string url, object data);
        Task PutAsync(string url, object data);
        Task DeleteAsync(string url);
    }
}
