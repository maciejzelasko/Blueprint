using Blueprint.App.Concepts.WeatherForecasts.GetWeatherForecasts;
using Blueprint.App.DI;
using Blueprint.Infrastructure.DI;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
{
    o.SwaggerDoc("v1", new OpenApiInfo { Title = "api", Version = "v1" });
    o.DescribeAllParametersInCamelCase();
});

builder.Services.AddInfrastructure();
builder.Services.AddBlueprintApp();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGet("WeatherForecast", async (ISender sender, CancellationToken cancellationToken, [FromQuery] int noDays) => 
{
    var result = await sender.Send(new GetWeatherForecastsQuery(noDays), cancellationToken);
    return Results.Ok(result);
});

app.Run();

public partial class Program
{
    // Expose the Program class for use with WebApplicationFactory<T>
}