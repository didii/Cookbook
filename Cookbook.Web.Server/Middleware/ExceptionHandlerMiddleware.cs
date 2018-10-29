using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Cookbook.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Cookbook.Web.Server.Middleware {
    public class ExceptionHandlerMiddleware {
        private readonly RequestDelegate _next;
        private readonly IHostingEnvironment _env;

        public ExceptionHandlerMiddleware(RequestDelegate next, IHostingEnvironment env) {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext context) {
            try {
                await _next.Invoke(context);
            }
            catch (Exception e) when (_env.IsDevelopment()) {
                var body = CreateExceptionBody(e, out var code);
                SetResponse(context, code, body);
            }
        }

        private void SetResponse(HttpContext context, HttpStatusCode status, JObject body) {
            if (!context.Response.HasStarted) {
                context.Response.StatusCode = (int)status;
                context.Response.WriteAsync(body.ToString());
            }
        }

        private JObject CreateExceptionBody(Exception e, out HttpStatusCode statusCode) {
            var result = new JObject {
                ["ExceptionType"] = e.GetType().FullName,
                [nameof(e.Message)] = e.Message,
                [nameof(e.StackTrace)] = e.StackTrace,
                [nameof(e.Data)] = JToken.FromObject(e.Data),
            };
            if (e.InnerException != null)
                result[nameof(e.InnerException)] = CreateExceptionBody(e.InnerException, out _);
            switch (e) {
                case NotFoundException notFound:
                    statusCode = HttpStatusCode.NotFound;
                    result[nameof(notFound.EntityType)] = notFound.EntityType.FullName;
                    result[nameof(notFound.EntityId)] = JToken.FromObject(notFound.EntityId);
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }
            return result;
        }
    }
}