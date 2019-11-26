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
            services.AddScoped<ICityRepository, CityRepository>();
            services.AddScoped<IClassRepository, ClassRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyUserRepository, CompanyUserRepository>();
            services.AddScoped<IOpportunityRepository, OpportunityRepository>();
            services.AddScoped<IPageOwnerRepository, PageOwnerRepository>();
            services.AddScoped<IPageRepository, PageRepository>();
            services.AddScoped<ISessionRepository, SessionRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<List<Notification>>();
            services.AddScoped<INotify, Notify>();
            services.AddScoped<DataContext, DataContext>();

            // Services
            services.AddScoped<IClassService, ClassService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IJWTService, JWTService>();
            services.AddScoped<IOpportunityService, OpportunityService>();
            services.AddScoped<IPageServer, PageServer>();
            services.AddScoped<ISessionService, SessionService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
