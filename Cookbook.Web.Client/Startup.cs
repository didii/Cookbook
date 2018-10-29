using Cookbook.Web.Client.Services;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Web.Client {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddSingleton<IDetailsService, DetailsService>();
        }

        public void Configure(IBlazorApplicationBuilder app) {
            app.AddComponent<App>("app");
        }
    }
}