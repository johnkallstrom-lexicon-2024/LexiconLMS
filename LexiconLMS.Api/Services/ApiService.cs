using LexiconLMS.Core.Exceptions;
using LexiconLMS.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace LexiconLMS.Api.Services
{
    public class ApiService<TEntity> : ApiService<TEntity, int> where TEntity : class, IEntity, IEquatable<TEntity>, new()
    {
        public ApiService(HttpClient httpClient, IConfiguration configuration) : base(httpClient, configuration) { }
    }

    public class ApiService<TEntity, TKey>
        : IService<TEntity, TKey>
        where TEntity : class, IEntity, IEquatable<TEntity>, new()
        where TKey : notnull, IEquatable<TKey>
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl;

        public ApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _apiUrl = $"{configuration["ApiUrl"]}/{typeof(TEntity).Name.ToLower()}";
        }

        public async Task<IEnumerable<TEntity>> GetAsync(CancellationToken cancellation = default)
        {
            HttpResponseMessage? response = null;
            string? jsonResponse = null;

            try
            {
                response = await _httpClient.GetAsync(_apiUrl, cancellation);
                response.EnsureSuccessStatusCode();

                jsonResponse = await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                throw new ApiException("Failed to retrieve entities.", ex);
            }

            var result = JsonConvert.DeserializeObject<IEnumerable<TEntity>>(jsonResponse);
            return result ?? throw new ApiException("Failed to deserialize response.");
        }

        public async Task<TEntity> GetAsync(TKey id, CancellationToken cancellation = default)
        {
            HttpResponseMessage? response = null;
            string? jsonResponse = null;

            try
            {
                cancellation.ThrowIfCancellationRequested();
                response = await _httpClient.GetAsync($"{_apiUrl}/{id}", cancellation);
                response.EnsureSuccessStatusCode();

                jsonResponse = await response.Content.ReadAsStringAsync(cancellation);
            }
            catch (Exception ex)
            {
                throw new ApiException("Failed to retrieve entity.", ex);
            }

            var result = JsonConvert.DeserializeObject<TEntity>(jsonResponse);
            return result ?? throw new ApiException($"Entity with ID {id} not found.");
        }

        public async Task CreateAsync(TEntity entity, CancellationToken cancellation = default)
        {
            var json = JsonConvert.SerializeObject(entity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                cancellation.ThrowIfCancellationRequested();
                var response = await _httpClient.PostAsync(_apiUrl, content, cancellation);
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApiException("Failed to create entity.");
                }
            }
            catch (Exception ex)
            {
                throw new ApiException("Failed to create entity.", ex);
            }
        }

        public async Task UpdateAsync(TEntity entity, CancellationToken cancellation = default)
        {
            var json = JsonConvert.SerializeObject(entity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                cancellation.ThrowIfCancellationRequested();
                var response = await _httpClient.PutAsync($"{_apiUrl}/{entity.Id}", content, cancellation);
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApiException($"Failed to update entity with ID {entity.Id}. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new ApiException("Failed to update entity.", ex);
            }
        }

        public async Task DeleteAsync(TKey id, CancellationToken cancellation = default)
        {
            try
            {
                cancellation.ThrowIfCancellationRequested();
                var response = await _httpClient.DeleteAsync($"{_apiUrl}/{id}", cancellation);
                if (!response.IsSuccessStatusCode)
                {
                    throw new ApiException($"Failed to delete entity with ID {id}. Status code: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw new ApiException("Failed to delete entity.", ex);
            }
        }

        public async Task<OperationResult> ValidateAsync(TEntity entity, CancellationToken cancellation = default)
        {
            var json = JsonConvert.SerializeObject(entity);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage? response = null;
            string? jsonResponse = null;

            try
            {
                cancellation.ThrowIfCancellationRequested();
                response = await _httpClient.PostAsync($"{_apiUrl}/validate", content, cancellation);
                response.EnsureSuccessStatusCode();
                jsonResponse = await response.Content.ReadAsStringAsync(cancellation);
            }
            catch (Exception ex)
            {
                throw new ApiException("Failed to validate entity.", ex);
            }

            var result = JsonConvert.DeserializeObject<OperationResult>(jsonResponse);
            return result ?? throw new ApiException("Validation failed or returned null.");
        }
    }
}
