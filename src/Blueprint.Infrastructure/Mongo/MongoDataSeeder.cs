using Blueprint.Domain.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Blueprint.Infrastructure.Mongo;

internal class MongoDataSeeder : IHostedService
{
    private static readonly IReadOnlyCollection<string> Summaries = new[]
{
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly IMongoDatabase _database;
    private readonly IOptions<MongoOptions> _options;

    public MongoDataSeeder(IMongoDatabase database, IOptions<MongoOptions> options)
    {
        _database = database;
        _options = options;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        if (!_options.Value.SeedData.HasValue || (_options.Value.SeedData ?? false)) 
            return;

        var collections = await _database.ListCollectionNamesAsync(new ListCollectionNamesOptions 
        {
            Filter = new BsonDocument("name", "WeatherForecast")
        });
        if (!collections.Any()) 
        {
            await _database.CreateCollectionAsync("WeatherForecast");
            var collection = _database.GetCollection<WeatherForecast>("WeatherForecast");
            var random = new Random();
            var forecasts = new List<WeatherForecast>();
            foreach (var (summary, index) in Summaries.Select((summary, index) => (summary, index)))
            {
                forecasts.Add(new WeatherForecast(DateTime.Now.AddDays(index + 1), random.Next(-30, 30), summary));
            }
            await collection.InsertManyAsync(forecasts, cancellationToken: cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return _database.DropCollectionAsync("WeatherForecast");
    }
}