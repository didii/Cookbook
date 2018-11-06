using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Web.Client.Services.Exceptions;
using Microsoft.JSInterop;

namespace Cookbook.Web.Client.Services {
    class ApiHttpService : IApiHttpService {
        private readonly HttpClient _http;

        public ApiHttpService(HttpClient http) {
            _http = http;
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> GetAsync(string uri) {
            return await SendAsync(HttpMethod.Get, uri);
        }

        /// <inheritdoc />
        public async Task<T> GetAsync<T>(string uri) {
            return await SendAsync<T>(HttpMethod.Get, uri);
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> PostAsync(string uri, object body = null) {
            return await SendAsync(HttpMethod.Post, uri, body);
        }

        /// <inheritdoc />
        public async Task<T> PostAsync<T>(string uri, object body = null) {
            return await SendAsync<T>(HttpMethod.Post, uri, body);
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> PutAsync(string uri, object body = null) {
            return await SendAsync(HttpMethod.Put, uri, body);
        }

        /// <inheritdoc />
        public async Task<T> PutAsync<T>(string uri, object body = null) {
            return await SendAsync<T>(HttpMethod.Put, uri, body);
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> DeleteAsync(string uri) {
            return await SendAsync(HttpMethod.Delete, uri);
        }

        /// <inheritdoc />
        public async Task<T> DeleteAsync<T>(string uri) {
            return await SendAsync<T>(HttpMethod.Delete, uri);
        }

        private async Task<HttpResponseMessage> SendAsync(HttpMethod method, string uri, object body = null) {
            //Console.WriteLine($"Http {method} - {uri}");
            var request = new HttpRequestMessage(method, uri);
            if (body != null) {
                var jsonBody = Json.Serialize(body);
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }
            return await _http.SendAsync(request);
        }

        private async Task<T> SendAsync<T>(HttpMethod method, string uri, object body = null) {
            var response = await SendAsync(method, uri, body);
            if (response.IsSuccessStatusCode) {
                var responseBody = await response.Content.ReadAsStringAsync();
                return Json.Deserialize<T>(responseBody);
            }
            throw new HttpResponseException(response);
        }
    }
}