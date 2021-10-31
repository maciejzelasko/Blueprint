using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Blueprint.App.Models;
using Blueprint.Domain.Repositories;
using MediatR;

namespace Blueprint.App.Concepts.WeatherForecasts.GetWeatherForecasts;

internal sealed class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, IEnumerable<WeatherForecastDto>>
{
    private readonly IWeatherForecastRepo _weatherForecastRepo;
    private readonly IMapper _mapper;


    public GetWeatherForecastsQueryHandler(IWeatherForecastRepo weatherForecastRepo, IMapper mapper)
    {
        _weatherForecastRepo = weatherForecastRepo;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WeatherForecastDto>> Handle(GetWeatherForecastsQuery request,
        CancellationToken cancellationToken)
    {
        var weatherForecasts = await _weatherForecastRepo.GetAllAsync();
        return weatherForecasts.Select(_mapper.Map<WeatherForecastDto>).ToList();
    }
}
