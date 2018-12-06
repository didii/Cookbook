using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace Cookbook.Web.Client.Services {
    public interface IApiHttpService {
        Task<HttpResponseMessage> GetAsync(string uri);
        Task<T> GetAsync<T>(string uri);
        Task<HttpResponseMessage> PostAsync(string uri, object body = null);
        Task<T> PostAsync<T>(string uri, object body = null);
        Task<HttpResponseMessage> PutAsync(string uri, object body = null);
        Task<T> PutAsync<T>(string uri, object body = null);
        Task<HttpResponseMessage> PatchAsync(string uri, IEnumerable<Operation> ops);
        Task<TReturn> PatchAsync<TReturn>(string uri, IEnumerable<Operation> ops);
        Task<HttpResponseMessage> DeleteAsync(string uri);
        Task<T> DeleteAsync<T>(string uri);
        void AssertResponse(HttpResponseMessage response);
    }
}
