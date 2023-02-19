using Blueprint.App.Models;
using Blueprint.Domain.Repositories;
using Mapster;
using MediatR;

namespace Blueprint.App.Concepts.WeatherForecasts.GetWeatherForecasts;

internal sealed class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, IEnumerable<WeatherForecastDto>>
{
    private readonly IWeatherForecastRepo _weatherForecastRepo;

    public GetWeatherForecastsQueryHandler(IWeatherForecastRepo weatherForecastRepo)
    {
        _weatherForecastRepo = weatherForecastRepo;
    }

    public async Task<IEnumerable<WeatherForecastDto>> Handle(GetWeatherForecastsQuery request,
        CancellationToken cancellationToken)
    {
        var weatherForecasts = await _weatherForecastRepo.GetAllAsync(request.NoDays);
        return weatherForecasts.Select(wf => wf.Adapt<WeatherForecastDto>()).ToList();
    }
}
