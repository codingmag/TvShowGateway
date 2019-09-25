using Microsoft.Extensions.DependencyInjection;
using TvShowGateway.Data;

namespace TvShowGateway.Service
{
    public static class ConfigurationExtensions
    {
        public static void AddTvShowDbContext(this IServiceCollection services)
        {
            services.AddDbContext<TvShowDbContext>();
        }
    }
}
