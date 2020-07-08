using FluentValidation;

namespace Blueprint.App.Queries.GetWeatherForecasts
{
    public class GetWeatherForecastsQueryValidator : AbstractValidator<GetWeatherForecastsQuery>
    {
        public GetWeatherForecastsQueryValidator()
        {
            RuleFor(x => x.NoDays).GreaterThan(0);
        }
    }
}