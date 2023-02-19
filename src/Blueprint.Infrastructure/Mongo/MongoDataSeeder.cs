using Blueprint.Domain.Entities;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Blueprint.Infrastructure.Mongo;

internal class MongoDataSeeder : IHostedService
{
    private const string CollectionName = "WeatherForecast";
    private static readonly IReadOnlyCollection<(int Temp, string Summary)> WeatherForecasts = new[]
    {
        (-10, "Freezing"),
        (-5, "Bracing"),
        (0, "Chilly"),
        (5, "Cool"),
        (10, "Mild"),
        (20, "Warm"),
        (25, "Balmy"),
        (30, "Hot"),
        (35, "Sweltering"), 
        (40, "Scorching")
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
            Filter = new BsonDocument("name", CollectionName)
        }, cancellationToken);
        if (!await collections.AnyAsync(cancellationToken: cancellationToken)) 
        {
            await _database.CreateCollectionAsync(CollectionName, cancellationToken: cancellationToken);
            var collection = _database.GetCollection<WeatherForecast>(CollectionName);
            var forecasts = new List<WeatherForecast>();
            foreach (var (forecast, index) in WeatherForecasts.Select((summary, index) => (summary, index)))
            {
                forecasts.Add(new WeatherForecast(DateTime.Now.AddDays(index + 1), forecast.Temp, forecast.Summary));
            }
            await collection.InsertManyAsync(forecasts, cancellationToken: cancellationToken);
        }
    }

    public Task StopAsync(CancellationToken cancellationToken) => 
        _database.DropCollectionAsync(CollectionName, cancellationToken);
}