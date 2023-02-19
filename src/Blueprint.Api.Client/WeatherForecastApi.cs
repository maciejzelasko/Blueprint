using Blueprint.Api.Client.Models;
using Refit;

namespace Blueprint.Api.Client;

public interface IWeatherForecastApi : IDisposable
{
    [Get("/weatherForecast")]
    Task<ApiResponse<WeatherForecastDto>> GetAsync([Query] int noDays, CancellationToken cancellationToken);
}
