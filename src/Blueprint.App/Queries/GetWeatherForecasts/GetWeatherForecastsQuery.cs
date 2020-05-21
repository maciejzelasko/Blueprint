using System.Collections.Generic;
using Blueprint.App.Models;
using MediatR;

namespace Blueprint.App.Queries.GetWeatherForecasts
{
    public class GetWeatherForecastsQuery : IRequest<IEnumerable<WeatherForecastDto>>
    {
    }
}