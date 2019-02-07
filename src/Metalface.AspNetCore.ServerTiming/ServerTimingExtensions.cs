using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Metalface.AspNetCore.ServerTiming
{
    public static class ServerTimingExtensions
    {
        public static IServiceCollection AddServerTiming(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new System.ArgumentNullException(nameof(services));
            }

            return services;
        }

        public static IServiceCollection AddServerTiming(
            this IServiceCollection services,
            System.Action<ServerTimingOptions> options)
        {
            if (services == null)
            {
                throw new System.ArgumentNullException(nameof(services));
            }

            if (options == null)
            {
                throw new System.ArgumentNullException(nameof(options));
            }

            services.Configure(options);
            services.AddServerTiming();

            return services;
        }

        public static IApplicationBuilder UseServerTiming(this IApplicationBuilder builder)
        {
            if (builder == null)
            {
                throw new System.ArgumentNullException(nameof(builder));
            }

            return builder.UseMiddleware<ServerTimingMiddleware>();
        }
    }
}
