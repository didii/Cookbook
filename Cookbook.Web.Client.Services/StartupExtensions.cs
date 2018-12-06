using System;
using System.Collections.Generic;
using System.Text;
using Cookbook.Dtos;
using Cookbook.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Web.Client.Services {
    public static class StartupExtensions {
        public static void AddServices(this IServiceCollection services) {
            services.AddSingleton<IChangeTracker<RecipeUpdate>, ChangeTracker<RecipeUpdate>>();
            services.AddRule(typeof(StartupExtensions).Assembly, "Service");
        }
    }
}
