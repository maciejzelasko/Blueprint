using Blueprint.Infrastructure.Mongo.Seeds;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Blueprint.Infrastructure.Mongo;

internal static class MongoExtensions
{
    internal static IServiceCollection AddMongoDb(this IServiceCollection services)
    {
        services
            .AddOptions<MongoOptions>()
            .Configure<IConfiguration>((options, configuration) =>
            {
                configuration.GetSection(MongoOptions.Section).Bind(options);
            })
            .ValidateOnStart();
        services.AddSingleton<IValidateOptions<MongoOptions>, MongoOptionsValidator>();

        services.AddSingleton<IMongoClient>(provider =>
        {
            var mongoSetting = provider.GetRequiredService<IOptions<MongoOptions>>().Value;
            return new MongoClient(mongoSetting.ConnectionString);
        });
        services.AddSingleton<IMongoDatabase>(provider =>
        {
            var mongoSetting = provider.GetRequiredService<IOptions<MongoOptions>>().Value;
            var client = provider.GetRequiredService<IMongoClient>();
            return client.GetDatabase(mongoSetting.Database);
        });
        services.Scan(scan => 
            scan.FromAssemblyOf<MongoDataSeeder>()                    
                .AddClasses(c => c.AssignableTo<IMongoSeeder>())
                .AsImplementedInterfaces());
        services.AddHostedService<MongoDataSeeder>();
        
        return services;
    }
}