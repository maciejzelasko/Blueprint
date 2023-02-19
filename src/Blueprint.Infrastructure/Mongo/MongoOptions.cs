namespace Blueprint.Infrastructure.Mongo;

public class MongoOptions
{
    public const string Section = "Mongo";

    public string? ConnectionString { get; init; }
    public string? Database { get; init; }

    public bool? SeedData { get; init; }

    public bool ShouldSeedData => SeedData.HasValue && SeedData.Value;
}