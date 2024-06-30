﻿using System.Net.Http.Json;

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
        public async Task<TValue?> PostAsync<TValue>(string url, object data)
        {
            TValue? value = default!;
            var httpResponse = await _httpClient.PostAsJsonAsync(url, data);
            if (httpResponse.IsSuccessStatusCode)
            {
                value = await httpResponse.Content.ReadFromJsonAsync<TValue>();
            }

            return value;
        }

        public async Task PutAsync(string url, object data) => await _httpClient.PutAsJsonAsync(url, data);
        public async Task DeleteAsync(string url) => await _httpClient.DeleteAsync(url);
    }
}
