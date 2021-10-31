using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Blueprint.Domain.Entities;

[assembly: InternalsVisibleTo(nameof(Blueprint.Domain) + ".Tests")]
namespace Blueprint.Domain.Repositories;

public interface IWeatherForecastRepo
{
    Task<IReadOnlyCollection<WeatherForecast>> GetAllAsync();
}