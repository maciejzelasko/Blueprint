using AutoMapper;
using Blueprint.App.Models;
using Blueprint.Domain.Entities;

namespace Blueprint.App.Profiles;

public class WeatherForecastProfile : Profile
{
    public WeatherForecastProfile()
    {
        CreateMap<WeatherForecast, WeatherForecastDto>(); ;
    }
}
