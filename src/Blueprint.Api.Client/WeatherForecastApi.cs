using Blueprint.Api.Client.Models;
using RestEase;

namespace Blueprint.Api.Client;

[AllowAnyStatusCode]
public interface IWeatherForecastApi : IDisposable
{
    [Get("/weatherForecast")]
    Task<Response<WeatherForecastDto>> GetAsync([Query] int noDays, CancellationToken cancellationToken);
}
