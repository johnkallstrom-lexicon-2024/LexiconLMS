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

        public async Task<IEnumerable<TModel>> GetListAsync<TModel>(string url)
        {
            var httpResponse = await _httpClient.GetAsync(url);
            if (httpResponse.IsSuccessStatusCode)
            {
                var data = await httpResponse.Content.ReadFromJsonAsync<IEnumerable<TModel>>();
                if (data != null)
                {
                    return data;
                }
            }

            return Enumerable.Empty<TModel>();
        }

        public async Task<TModel?> GetAsync<TModel>(string url)
        {
            var httpResponse = await _httpClient.GetAsync(url);
            if (httpResponse.IsSuccessStatusCode)
            {
                var data = await httpResponse.Content.ReadFromJsonAsync<TModel>();
                if (data != null)
                {
                    return data;
                }
            }

            return default;
        }

        public async Task PostAsync<TModel>(string url, TModel data) => await _httpClient.PostAsJsonAsync(url, data);
        public async Task PutAsync<TModel>(string url, TModel data) => await _httpClient.PutAsJsonAsync(url, data);
        public async Task DeleteAsync(string url) => await _httpClient.DeleteAsync(url);
    }
}
