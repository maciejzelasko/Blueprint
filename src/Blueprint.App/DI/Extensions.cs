using Blueprint.App.Mappers;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Blueprint.App.DI
{
    public static class Extensions
    {
        public static IServiceCollection AddBlueprintApp(this IServiceCollection services)
        {
            return services.AddMediatR(typeof(Extensions).Assembly)
                .AddMappers();
        }

        private static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddScoped<IWeatherForecastMapper, WeatherForecastMapper>();
            return services;
        }
    }
}