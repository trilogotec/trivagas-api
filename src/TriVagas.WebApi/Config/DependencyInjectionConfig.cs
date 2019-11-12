using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TriVagas.Domain.Interfaces;
using TriVagas.Infra.Data.Context;
using TriVagas.Infra.Data.Repository;
using TriVagas.Services.Interfaces;
using TriVagas.Services.Notify;
using TriVagas.Services.Services;

namespace TriVagas.WebApi.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            // Infra.Data
            services.AddScoped<IOpportunityRepository, OpportunityRepository>();
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<IPageOwnerRepository, PageOwnerRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<List<Notification>>();
            services.AddScoped<INotify, Notify>();
            services.AddScoped<DataContext, DataContext>();

            // Services
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IPageServer, PageServer>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOpportunityService, OpportunityService>();

            return services;
        }
    }
}
