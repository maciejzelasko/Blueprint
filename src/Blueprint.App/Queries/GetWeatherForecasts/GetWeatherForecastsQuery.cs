using System.Collections.Generic;
using Blueprint.App.Models;
using MediatR;

namespace Blueprint.App.Queries.GetWeatherForecasts
{
    public class GetWeatherForecastsQuery : IRequest<IEnumerable<WeatherForecastDto>>
    {
        public GetWeatherForecastsQuery(int noDays)
        {
            NoDays = noDays;
        }

        public int NoDays { get; }
    }
}