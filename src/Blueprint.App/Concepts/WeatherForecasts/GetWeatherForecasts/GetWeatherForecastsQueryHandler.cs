using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Blueprint.App.Mappers;
using Blueprint.App.Models;
using Blueprint.Domain.Repositories;
using MediatR;

namespace Blueprint.App.Concepts.WeatherForecasts.GetWeatherForecasts
{
    internal sealed class
        GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, IEnumerable<WeatherForecastDto>>
    {
        private readonly IWeatherForecastMapper _weatherForecastMapper;
        private readonly IWeatherForecastRepo _weatherForecastRepo;

        public GetWeatherForecastsQueryHandler(IWeatherForecastRepo weatherForecastRepo,
            IWeatherForecastMapper weatherForecastMapper)
        {
            _weatherForecastRepo = weatherForecastRepo;
            _weatherForecastMapper = weatherForecastMapper;
        }

        public async Task<IEnumerable<WeatherForecastDto>> Handle(GetWeatherForecastsQuery request,
            CancellationToken cancellationToken)
        {
            var weatherForecasts = await _weatherForecastRepo.GetAllAsync();
            return weatherForecasts.Select(_weatherForecastMapper.Map);
        }
    }
}