using Blueprint.App.Validators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Blueprint.App.DI;

public static class Extensions
{
    public static IServiceCollection AddBlueprintApp(this IServiceCollection services)
    {
        var assembly = typeof(Extensions).Assembly;
        return services
            .AddMediatR(assembly)
            .AddValidationBehavior()
            .AddValidatorsFromAssemblies(new[] { assembly });
    }

    private static IServiceCollection AddValidationBehavior(this IServiceCollection services) =>
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
}
