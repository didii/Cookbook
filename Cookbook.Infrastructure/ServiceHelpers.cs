using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Infrastructure {
    public static class ServiceHelpers {
        public static void AddRule(this IServiceCollection services, Assembly assembly, string suffix) {
            var interfaces = assembly.ExportedTypes.Where(t => t.IsInterface && t.Name.EndsWith(suffix));
            foreach (var @interface in interfaces) {
                var @class = assembly.DefinedTypes.FirstOrDefault(t => t.IsClass && t.Name == @interface.Name.Substring(1));
                if (@class == null)
                    continue;
                services.AddScoped(@interface, @class);
            }
        }
    }
}
