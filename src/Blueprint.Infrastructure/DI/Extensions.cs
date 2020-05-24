using Blueprint.Domain.Repositories;
using Blueprint.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Blueprint.Infrastructure.DI
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastRepo, WeatherForecastRepo>();
            return services;
        }
    }
}