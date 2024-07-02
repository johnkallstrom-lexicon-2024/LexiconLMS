using LexiconLMS.Core.Models.Authenticate;
using System.Net.Http.Headers;

namespace LexiconLMS.Http.Services
{
    public class HttpService : IHttpService
    {
        private readonly ISessionStorageService _sessionStorage;
        private readonly HttpClient _httpClient;

        public HttpService(HttpClient httpClient, ISessionStorageService sessionStorage)
        {
            _httpClient = httpClient;
            _sessionStorage = sessionStorage;
        }

        public async Task<TData?> GetAsync<TData>(string url)
        {
            await SetAuthorizationHeader();

            TData? data = default;

            var httpResponse = await _httpClient.GetAsync(url);
            if (httpResponse.IsSuccessStatusCode)
            {
                data = await httpResponse.Content.ReadFromJsonAsync<TData>();
            }

            return data;
        }

        public async Task PostAsync(string url, object data)
        {
            await SetAuthorizationHeader();
            await _httpClient.PostAsJsonAsync(url, data);
        }

        public async Task<AuthenticateResponse?> PostLoginAsync(string url, object data)
        {
            AuthenticateResponse? response = default!;

            var httpResponse = await _httpClient.PostAsJsonAsync(url, data);
            if (httpResponse.IsSuccessStatusCode)
            {
                response = await httpResponse.Content.ReadFromJsonAsync<AuthenticateResponse>();
            }

            return response;
        }

        public async Task PutAsync(string url, object data)
        {
            await SetAuthorizationHeader();
            await _httpClient.PutAsJsonAsync(url, data);
        }
        public async Task DeleteAsync(string url)
        {
            await SetAuthorizationHeader();
            await _httpClient.DeleteAsync(url);
        }

        private async Task SetAuthorizationHeader()
        {
            string? token = await _sessionStorage.GetItemAsStringAsync("token");
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
