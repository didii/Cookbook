using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Web.Client.Services.Exceptions;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
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
        public async Task<HttpResponseMessage> PatchAsync(string uri, IEnumerable<Operation> patch) {
            return await SendAsync(new HttpMethod("PATCH"), uri, patch);
        }

        /// <inheritdoc />
        public async Task<TReturn> PatchAsync<TReturn>(string uri, IEnumerable<Operation> patch) {
            return await SendAsync<TReturn>(new HttpMethod("PATCH"), uri, patch);
        }

        /// <inheritdoc />
        public async Task<HttpResponseMessage> DeleteAsync(string uri) {
            return await SendAsync(HttpMethod.Delete, uri);
        }

        /// <inheritdoc />
        public async Task<T> DeleteAsync<T>(string uri) {
            return await SendAsync<T>(HttpMethod.Delete, uri);
        }

        /// <inheritdoc />
        public void AssertResponse(HttpResponseMessage response) {
            if (!response.IsSuccessStatusCode)
                throw new HttpResponseException(response);
        }

        private async Task<HttpResponseMessage> SendAsync(HttpMethod method, string uri, object body = null) {
            var request = CreateRequest(method, uri, body);
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

        private async Task<T> SendAsync<T>(HttpRequestMessage request) {
            var response = await _http.SendAsync(request);
            if (response.IsSuccessStatusCode) {
                var responseBody = await response.Content.ReadAsStringAsync();
                return Json.Deserialize<T>(responseBody);
            }
            throw new HttpResponseException(response);
        }

        private HttpRequestMessage CreateRequest(HttpMethod method, string uri, object body = null) {
            var request = new HttpRequestMessage(method, uri);
            if (body != null) {
                var jsonBody = Json.Serialize(body);
                request.Content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            }
            return request;
        }
    }
}