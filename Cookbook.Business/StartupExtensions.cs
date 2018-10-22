using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Cookbook.Business.Mapper;
using Cookbook.Db;
using Cookbook.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cookbook.Business {
    public static class StartupExtensions {
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration config) {
            //Automapper
            var mappingConfig = new MapperConfiguration(x => x.AddProfile<MapperProfile>());
            services.AddScoped(x => mappingConfig.CreateMapper());

            //Services
            services.AddRule(typeof(StartupExtensions).Assembly, "Service");

            //Add other services
            services.AddDbServices(config);
        }
    }
}
