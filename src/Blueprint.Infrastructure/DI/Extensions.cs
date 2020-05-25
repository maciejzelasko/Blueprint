using System.Runtime.CompilerServices;
using Blueprint.Domain.Repositories;
using Blueprint.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

[assembly: InternalsVisibleTo("Blueprint.Infrastructure.Tests")]
[assembly: InternalsVisibleTo("Blueprint.Api.Tests")]

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