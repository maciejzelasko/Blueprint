using System;

namespace Blueprint.App.Models
{
    public class WeatherForecastDto
    {
        public WeatherForecastDto(DateTime date, int temperatureC, int temperatureF, string summary)
        {
            Date = date;
            TemperatureC = temperatureC;
            TemperatureF = temperatureF;
            Summary = summary;
        }

        public DateTime Date { get; }

        public int TemperatureC { get; }

        public int TemperatureF { get; }

        public string Summary { get; }
    }
}