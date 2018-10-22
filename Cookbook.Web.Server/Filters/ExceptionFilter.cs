using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace Cookbook.Web.Server.Filters {
    public class ExceptionFilter : ExceptionFilterAttribute {
        private readonly IHostingEnvironment _env;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public ExceptionFilter(IHostingEnvironment env, IModelMetadataProvider modelMetadataProvider) {
            _env = env;
            _modelMetadataProvider = modelMetadataProvider;
        }

        public override void OnException(ExceptionContext context) {
            context.Result = new JsonResult(context.Exception, new JsonSerializerSettings() {
                NullValueHandling = NullValueHandling.Ignore
            });
        }
    }
}