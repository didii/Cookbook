using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Web.Client {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
        }

        public void Configure(IBlazorApplicationBuilder app) {
            app.AddComponent<App>("app");
        }
    }
}
