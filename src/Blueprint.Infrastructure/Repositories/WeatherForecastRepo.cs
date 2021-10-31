using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blueprint.Domain.Entities;
using Blueprint.Domain.Repositories;

namespace Blueprint.Infrastructure.Repositories;

internal sealed class WeatherForecastRepo : IWeatherForecastRepo
{
    private static readonly string[] Summaries =
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    public Task<IReadOnlyCollection<WeatherForecast>> GetAllAsync()
    {
        var rng = new Random();
        IReadOnlyCollection<WeatherForecast> result = Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast(DateTime.Now.AddDays(index), rng.Next(-20, 55),
                Summaries[rng.Next(Summaries.Length)]))
            .ToArray();
        return Task.FromResult(result);
    }
}
