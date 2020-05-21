using System.Collections.Generic;
using System.Threading.Tasks;
using Blueprint.Domain.Entities;

namespace Blueprint.Domain.Repositories
{
    public interface IWeatherForecastRepo
    {
        Task<IReadOnlyCollection<WeatherForecast>> GetAllAsync();
    }
}