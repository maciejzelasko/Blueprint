using Blueprint.Domain.Entities;
using Blueprint.Domain.Repositories;

namespace Blueprint.Infrastructure.Repositories;

internal sealed class WeatherForecastRepo : IWeatherForecastRepo
{
    private static readonly IReadOnlyCollection<string> Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<IReadOnlyCollection<WeatherForecast>> GetAllAsync()
    {
        var rng = new Random();
        var result = 
            Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast(DateTime.Now.AddDays(index), rng.Next(-20, 55), Summaries.ElementAt(rng.Next(Summaries.Count))));
        return Task.FromResult<IReadOnlyCollection<WeatherForecast>>(result.ToArray());
    }
}
