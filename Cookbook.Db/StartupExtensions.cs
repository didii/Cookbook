using Cookbook.Db.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Db {
    public static class StartupExtensions {
        public static void AddDbServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<ISeeder, CookbookSeeder>();
            services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); });
        }
    }
}