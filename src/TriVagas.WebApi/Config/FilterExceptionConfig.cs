using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace TriVagas.WebApi.Config
{
    public static class FilterExceptionConfig
    {
        public static IServiceCollection ResolveFilterException(this IServiceCollection services)
        {
            services.AddMvc(options => {
                options.Filters.Add(typeof(FilterException));
                options.Filters.Add(typeof(FilterExceptionModelStates));
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            return services;
        }
    }
}
