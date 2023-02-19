using Blueprint.Domain.Entities;
using Blueprint.Domain.Repositories;
using MongoDB.Driver;

namespace Blueprint.Infrastructure.Repositories;

internal sealed class WeatherForecastRepo : IWeatherForecastRepo
{
    private readonly IMongoCollection<WeatherForecast> _collection;

    public WeatherForecastRepo(IMongoDatabase database)
    {
        _collection = database.GetCollection<WeatherForecast>("WeatherForecast");
    }

    public async Task<IReadOnlyCollection<WeatherForecast>> GetAllAsync()
    {
        var result = await _collection.AsQueryable().ToListAsync();
        return result;
    }
}
