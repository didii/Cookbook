using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cookbook.Web.Client.Services.Exceptions;
using Microsoft.JSInterop;

namespace Cookbook.Web.Client.Services.Extensions {
    internal static class HttpClientExtensions {
        public static async Task<HttpResponseMessage> PostJsonAsync(this HttpClient source, string uri, object body) {
            var content = new StringContent(Json.Serialize(body));
            return await source.PostAsync(uri, content);
        }

        public static async Task<T> PostJsonAsync<T>(this HttpClient source, string uri, object body) {
            var response = await source.PostJsonAsync(uri, body);
            if (response.IsSuccessStatusCode) {
                var responseBody = await response.Content.ReadAsStringAsync();
                return Json.Deserialize<T>(responseBody);
            }
            throw new HttpResponseException(response);
        }
    }
}
