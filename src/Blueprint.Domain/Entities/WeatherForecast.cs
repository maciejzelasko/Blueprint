using System;

namespace Blueprint.Domain.Entities
{


    public class WeatherForecast : Entity<WeatherForecastId>
    {
        private WeatherForecast()
        {
        }

        public WeatherForecast(DateTime date, int temperatureC, string summary) : base(new WeatherForecastId(Guid.NewGuid()))
        {
            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
        }

        public DateTime Date { get; protected set; }

        public int TemperatureC { get; protected set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; protected set; }

        public override WeatherForecastId EmptyValue => WeatherForecastId.Empty;
    }
}