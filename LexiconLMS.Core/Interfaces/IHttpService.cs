using LexiconLMS.Core.Models.Authenticate;

namespace LexiconLMS.Core.Interfaces
{
    public interface IHttpService
    {
        Task<TData?> GetAsync<TData>(string url);
        Task PostAsync(string url, object data);
        Task<AuthenticateResponse?> PostLoginAsync(string url, object data);
        Task PutAsync(string url, object data);
        Task DeleteAsync(string url);
    }
}
