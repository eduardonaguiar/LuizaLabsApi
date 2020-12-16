using System;
using AutoMapper;
using LuizaLabs.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace LuizaLabs.Api.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}
