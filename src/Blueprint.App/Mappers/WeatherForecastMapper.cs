using Blueprint.App.Models;
using Blueprint.Domain.Entities;

namespace Blueprint.App.Mappers
{
    public interface IWeatherForecastMapper
    {
        WeatherForecastDto Map(WeatherForecast weatherForecast);
    }

    internal sealed class WeatherForecastMapper : IWeatherForecastMapper
    {
        public WeatherForecastDto Map(WeatherForecast weatherForecast)
        {
            return new WeatherForecastDto(weatherForecast.Date, weatherForecast.TemperatureC,
                weatherForecast.TemperatureF, weatherForecast.Summary);
        }
    }
}