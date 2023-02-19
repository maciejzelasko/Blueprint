using Blueprint.Domain.Entities;
using Blueprint.Domain.Repositories;
using Blueprint.Infrastructure.Documents;
using MongoDB.Driver;

namespace Blueprint.Infrastructure.Repositories;

internal sealed class WeatherForecastRepo : IWeatherForecastRepo
{
    private readonly IMongoCollection<WeatherForecast> _collection;

    public WeatherForecastRepo(IMongoDatabase database)
    {
        _collection = database.GetCollection<WeatherForecast>(WeatherForecastDoc.CollectionName);
    }

    public async Task<IReadOnlyCollection<WeatherForecast>> GetAllAsync(int take)
    {
        var result = await _collection.FindAsync(Builders<WeatherForecast>.Filter.Empty, new FindOptions<WeatherForecast>
        {
            Limit = take
        });
        return await result.ToListAsync();
    }
}
