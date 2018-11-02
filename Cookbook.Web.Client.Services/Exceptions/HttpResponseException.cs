using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Cookbook.Web.Client.Services.Exceptions {
    public class HttpResponseException : Exception {
        public HttpResponseMessage Response { get; set; }

        public HttpResponseException(HttpResponseMessage response) : base($"A request to {response.RequestMessage.RequestUri} failed") {
            Response = response;
        }
    }
}
