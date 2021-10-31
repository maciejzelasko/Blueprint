namespace Blueprint.Api.Client.Models
{
    public class WeatherForecastDto
    {
        public DateTime Date { get; init; }

        public int TemperatureC { get; init; }

        public int TemperatureF { get; init; }

        public string Summary { get; init; }
    }
}