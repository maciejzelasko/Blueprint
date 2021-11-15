using Xunit;

namespace Blueprint.Api.IntegrationTests.Infrastructure;

[CollectionDefinition(Name)]
public sealed class BlueprintAppCollection : ICollectionFixture<BlueprintAppFixture>
{
    public const string Name = "Blueprint server collection";
}