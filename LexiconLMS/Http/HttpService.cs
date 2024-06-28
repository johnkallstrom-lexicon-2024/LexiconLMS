using LexiconLMS.Core.Interfaces;

namespace LexiconLMS.Http
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

        public Task PostAsync(string url, object data)
        {
            throw new NotImplementedException();
        }

        public Task PutAsync(string url, object data)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string url)
        {
            throw new NotImplementedException();
        }
    }
}
