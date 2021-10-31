using System.Runtime.CompilerServices;
using Blueprint.Domain.Entities;

[assembly: InternalsVisibleTo(nameof(Blueprint.Domain) + ".Tests")]
namespace Blueprint.Domain.Repositories;

public interface IWeatherForecastRepo
{
    Task<IReadOnlyCollection<WeatherForecast>> GetAllAsync();
}