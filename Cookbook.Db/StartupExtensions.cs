using System;
using Cookbook.Db.Contexts;
using Cookbook.Domain;
using Cookbook.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Db {
    public static class StartupExtensions {
        public static void AddDbServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<ISeeder, CookbookSeeder>();
            services.AddDbContext<IDbContext, ApplicationDbContext>(options => { options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")); });

            services.AddIdentityCore<User>().AddDefaultTokenProviders().AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddRule(typeof(StartupExtensions).Assembly, "Repository");
        }
    }
}