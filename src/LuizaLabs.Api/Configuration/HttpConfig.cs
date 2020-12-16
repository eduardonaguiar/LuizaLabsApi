using LuizaLabs.Domain.DomainService;
using LuizaLabs.Service;
using LuizaLabs.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LuizaLabs.Api.Configuration
{
    public static class HttpConfig
    {
        public static void AddHttpConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            
            services.AddHttpClient<IProductSearchService, ProductSearchService>(client =>
            {
                client.BaseAddress = new Uri(configuration["SearchProductHost"]);
            });
        }
        
    }
}
