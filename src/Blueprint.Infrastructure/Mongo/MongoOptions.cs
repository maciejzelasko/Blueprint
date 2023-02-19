namespace Blueprint.Infrastructure.Mongo;

public class MongoOptions
{
    public const string Section = "Mongo";

    public string? ConnectionString { get; init; }
    public string? Database { get; init; }
}