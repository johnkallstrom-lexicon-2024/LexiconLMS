using LexiconLMS.Core.Models.Authenticate;
using System.Net.Http.Json;

namespace LexiconLMS.Core.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TData?> GetAsync<TData>(string url)
        {
            TData? data = default;

            var httpResponse = await _httpClient.GetAsync(url);
            if (httpResponse.IsSuccessStatusCode)
            {
                data = await httpResponse.Content.ReadFromJsonAsync<TData>();
            }

            return data;
        }

        public async Task PostAsync(string url, object data) => await _httpClient.PostAsJsonAsync(url, data);
        public async Task PutAsync(string url, object data) => await _httpClient.PutAsJsonAsync(url, data);
        public async Task DeleteAsync(string url) => await _httpClient.DeleteAsync(url);

        public async Task<AuthenticateResponse> LoginAsync(string url, AuthenticateRequest request)
        {
            var httpResponse = await _httpClient.PostAsJsonAsync(url, request);
            if (httpResponse.IsSuccessStatusCode)
            {
                var result = await httpResponse.Content.ReadFromJsonAsync<AuthenticateResponse>();
                if (result != null)
                {
                    return result;
                }
            }

            return default!;
        }
    }
}
