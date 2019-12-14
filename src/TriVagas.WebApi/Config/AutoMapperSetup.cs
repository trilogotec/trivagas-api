using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using TriVagas.Services.AutoMapper;

namespace TriVagas.WebApi.Config
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            AutoMapperConfig.RegisterMappings();
        }
    }
}
