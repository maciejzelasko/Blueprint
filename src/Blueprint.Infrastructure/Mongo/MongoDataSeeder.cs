using Blueprint.Domain.Entities;
using Microsoft.Extensions.Hosting;
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

    public MongoDataSeeder(IMongoDatabase database)
    {
        _database = database;
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var collections = await _database.ListCollectionNamesAsync(new ListCollectionNamesOptions 
        {
            Filter = new BsonDocument("name", "WeatherForecast")
        });
        if (!collections.Any()) 
        {
            await _database.CreateCollectionAsync("WeatherForecast");
            var collection = _database.GetCollection<WeatherForecast>("WeatherForecast");
            await collection.InsertManyAsync(new[] {
                new WeatherForecast(DateTime.Now.AddDays(1), 1, "Freezing"),
                new WeatherForecast(DateTime.Now.AddDays(2), 14, "Bracing"),
                new WeatherForecast(DateTime.Now.AddDays(3), -13, "Chilly"),
            });
        }
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}