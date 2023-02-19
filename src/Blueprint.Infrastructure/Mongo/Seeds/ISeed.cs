using Blueprint.Domain.Entities;
using Blueprint.Infrastructure.Documents;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Blueprint.Infrastructure.Mongo.Seeds;

internal interface IMongoSeeder
{
    Task Seed(CancellationToken cancellationToken);

    Task Cleanup(CancellationToken cancellationToken);
}

internal abstract class MongoSeeder : IMongoSeeder
{
    protected readonly IMongoDatabase Database;
    
    protected MongoSeeder(IMongoDatabase database)
    {
        Database = database;
    }

    public abstract Task Seed(CancellationToken cancellationToken);
    public abstract Task Cleanup(CancellationToken cancellationToken);
}

internal sealed class WeatherForecastSeeder : MongoSeeder
{
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
    
    public WeatherForecastSeeder(IMongoDatabase database) : base(database)
    {
    }

    public override async Task Seed(CancellationToken cancellationToken)
    {
        var collections = await Database.ListCollectionNamesAsync(new ListCollectionNamesOptions 
        {
            Filter = new BsonDocument("name", WeatherForecastDoc.CollectionName)
        }, cancellationToken);
        if (!await collections.AnyAsync(cancellationToken: cancellationToken)) 
        {
            await Database.CreateCollectionAsync(WeatherForecastDoc.CollectionName, cancellationToken: cancellationToken);
            var collection = Database.GetCollection<WeatherForecast>(WeatherForecastDoc.CollectionName);
            var forecasts = new List<WeatherForecast>();
            foreach (var (forecast, index) in WeatherForecasts.Select((summary, index) => (summary, index)))
            {
                forecasts.Add(new WeatherForecast(DateTime.Now.AddDays(index + 1), forecast.Temp, forecast.Summary));
            }
            await collection.InsertManyAsync(forecasts, cancellationToken: cancellationToken);
        }
    }

    public override Task Cleanup(CancellationToken cancellationToken) => 
        Database.DropCollectionAsync(WeatherForecastDoc.CollectionName, cancellationToken);
}