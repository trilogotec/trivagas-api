using Microsoft.Extensions.DependencyInjection;
using TriVagas.Services.Interfaces;
using TriVagas.Services.Services;

namespace TriVagas.WebApi.Dependecies
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisteredServicesAndRepository(this IServiceCollection services)
        {
            services.AddTransient<IOpportunityService, OpportunityService>();

            return services;
        }
    }
}
