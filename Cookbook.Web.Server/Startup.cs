using System.Linq;
using System.Net.Mime;
using Cookbook.Business;
using Cookbook.Web.Server.Filters;
using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;

namespace Cookbook.Web.Server {
    public class Startup {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _config;
        private readonly ILoggerFactory _loggerFactory;

        public Startup(IHostingEnvironment env, IConfiguration config, ILoggerFactory loggerFactory) {
            _env = env;
            _config = config;
            _loggerFactory = loggerFactory;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddMvc(x => x.Filters.Add<ExceptionFilter>());

            services.AddSwaggerGen(x => { x.SwaggerDoc("v1", new Info() { Title = "Cookbook", Description = "The cookbook recipe API" }); });

            services.AddResponseCompression(options => {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] {
                    MediaTypeNames.Application.Octet,
                    WasmMediaTypeNames.Application.Wasm,
                });
            });

            services.AddBusinessServices(_config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            app.UseResponseCompression();

            //if (env.IsDevelopment()) {
            //    app.UseDeveloperExceptionPage();
            //}

            app.UseMvc(routes => { routes.MapRoute(name: "default", template: "{controller}/{action}/{id?}"); });

            app.UseSwagger();
            app.UseSwaggerUI(x => {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Cookbook");
            });

            app.UseBlazor<Client.Startup>();
        }
    }
}