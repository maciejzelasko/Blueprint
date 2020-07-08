using System.Collections.Generic;
using System.Threading.Tasks;
using Blueprint.App.Models;
using Blueprint.App.Queries.GetWeatherForecasts;
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
        public async Task<IEnumerable<WeatherForecastDto>> Get([FromQuery] int noDays) =>
            await _mediator.Send(new GetWeatherForecastsQuery(noDays));
    }
}