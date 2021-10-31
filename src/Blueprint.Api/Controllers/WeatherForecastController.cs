using Blueprint.App.Concepts.WeatherForecasts.GetWeatherForecasts;
using Blueprint.App.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Blueprint.Api.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator _mediator;

    public WeatherForecastController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public Task<IEnumerable<WeatherForecastDto>> Get([FromQuery] int noDays) =>
        _mediator.Send(new GetWeatherForecastsQuery(noDays));
}
