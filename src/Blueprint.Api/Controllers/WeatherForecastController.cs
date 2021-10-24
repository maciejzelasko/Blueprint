using System.Collections.Generic;
using System.Threading.Tasks;
using Blueprint.App.Concepts.WeatherForecasts.GetWeatherForecasts;
using Blueprint.App.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blueprint.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WeatherForecastController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public Task<IEnumerable<WeatherForecastDto>> Get([FromQuery] int noDays) =>
            _mediator.Send(new GetWeatherForecastsQuery(noDays));
    }
}