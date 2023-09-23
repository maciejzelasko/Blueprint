using StronglyTypedIds;

namespace Blueprint.Domain.Entities;

[StronglyTypedId(converters: StronglyTypedIdConverter.SystemTextJson)]
public partial struct WeatherForecastId
{
}
