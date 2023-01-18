using System.Globalization;
using System.Text.Json.Serialization;

public static class ApiSettings
{
    // Dates in the API are not ISO 8601
    public const string ApiDateFormat = "yyyy-MM-dd HH:mm:ff";
}

public record Cloud(
    [property: JsonPropertyName("oktas")] int Oktas,
    [property: JsonPropertyName("trend")] int Trend,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lng")] double Lng,
    [property: JsonPropertyName("distance")] double Distance
);

public record Day(
    [property: JsonPropertyName("dateTime")] string DateTimeValue,
    [property: JsonPropertyName("entries")] IReadOnlyList<Entry> Entries)
{
    public DateTime DateTime => DateTime.ParseExact(DateTimeValue, ApiSettings.ApiDateFormat, CultureInfo.InvariantCulture);
}

public record DeltaT(
    [property: JsonPropertyName("temperature")] double Temperature,
    [property: JsonPropertyName("trend")] int Trend,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lng")] double Lng,
    [property: JsonPropertyName("distance")] double Distance
);

public record DewPoint(
    [property: JsonPropertyName("temperature")] double Temperature,
    [property: JsonPropertyName("trend")] int Trend,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lng")] double Lng,
    [property: JsonPropertyName("distance")] double Distance
);

public record Entry(
    [property: JsonPropertyName("dateTime")] string DateTimeValue,
    [property: JsonPropertyName("precisCode")] string PrecisCode,
    [property: JsonPropertyName("precis")] string Precis,
    [property: JsonPropertyName("precisOverlayCode")] string PrecisOverlayCode,
    [property: JsonPropertyName("night")] bool Night,
    [property: JsonPropertyName("min")] int Min,
    [property: JsonPropertyName("max")] int Max)
{
    public DateTime DateTime => DateTime.ParseExact(DateTimeValue, ApiSettings.ApiDateFormat, CultureInfo.InvariantCulture);
}

public record Forecasts(
    [property: JsonPropertyName("weather")] Weather Weather
);

public record Humidity(
    [property: JsonPropertyName("percentage")] int Percentage,
    [property: JsonPropertyName("trend")] int Trend,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lng")] double Lng,
    [property: JsonPropertyName("distance")] double Distance
);

public record Location(
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("region")] string Region,
    [property: JsonPropertyName("state")] string State,
    [property: JsonPropertyName("postcode")] string Postcode,
    [property: JsonPropertyName("timeZone")] string TimeZone,
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lng")] double Lng,
    [property: JsonPropertyName("typeId")] int TypeId
);

public record Observational(
    [property: JsonPropertyName("observations")] Observations Observations,
    [property: JsonPropertyName("stations")] Stations Stations,
    [property: JsonPropertyName("issueDateTime")] string IssueDateTimeValue,
    [property: JsonPropertyName("units")] Units Units)
{
    public DateTime IssueDateTime => DateTime.ParseExact(IssueDateTimeValue, ApiSettings.ApiDateFormat, CultureInfo.InvariantCulture);
}

public record Observations(
    [property: JsonPropertyName("temperature")] Temperature Temperature,
    [property: JsonPropertyName("delta-t")] DeltaT DeltaT,
    [property: JsonPropertyName("cloud")] Cloud Cloud,
    [property: JsonPropertyName("humidity")] Humidity Humidity,
    [property: JsonPropertyName("dewPoint")] DewPoint DewPoint,
    [property: JsonPropertyName("pressure")] Pressure Pressure,
    [property: JsonPropertyName("wind")] Wind Wind,
    [property: JsonPropertyName("rainfall")] Rainfall Rainfall
);

public record Pressure(
    [property: JsonPropertyName("pressure")] double PressureValue,
    [property: JsonPropertyName("trend")] int Trend,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lng")] double Lng,
    [property: JsonPropertyName("distance")] double Distance
);

public record Rainfall(
    [property: JsonPropertyName("lastHourAmount")] int LastHourAmount,
    [property: JsonPropertyName("todayAmount")] int TodayAmount,
    [property: JsonPropertyName("since9AMAmount")] int Since9AMAmount,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lng")] double Lng,
    [property: JsonPropertyName("distance")] double Distance
);

public record WeatherByLocation(
    [property: JsonPropertyName("location")] Location Location,
    [property: JsonPropertyName("forecasts")] Forecasts Forecasts,
    [property: JsonPropertyName("observational")] Observational Observational
);

public record Stations(
    [property: JsonPropertyName("temperature")] Temperature Temperature,
    [property: JsonPropertyName("delta-t")] DeltaT DeltaT,
    [property: JsonPropertyName("cloud")] Cloud Cloud,
    [property: JsonPropertyName("humidity")] Humidity Humidity,
    [property: JsonPropertyName("dewPoint")] DewPoint DewPoint,
    [property: JsonPropertyName("pressure")] Pressure Pressure,
    [property: JsonPropertyName("wind")] Wind Wind,
    [property: JsonPropertyName("rainfall")] Rainfall Rainfall
);

public record Temperature(
    [property: JsonPropertyName("temperature")] double TemperatureValue,
    [property: JsonPropertyName("apparentTemperature")] double ApparentTemperature,
    [property: JsonPropertyName("trend")] int Trend,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lng")] double Lng,
    [property: JsonPropertyName("distance")] double Distance
);

public record Units(
    [property: JsonPropertyName("temperature")] string Temperature,
    [property: JsonPropertyName("amount")] string Amount,
    [property: JsonPropertyName("speed")] string Speed,
    [property: JsonPropertyName("distance")] string Distance,
    [property: JsonPropertyName("pressure")] string Pressure
);

public record Weather(
    [property: JsonPropertyName("days")] IReadOnlyList<Day> Days,
    [property: JsonPropertyName("units")] Units Units,
    [property: JsonPropertyName("issueDateTime")] string IssueDateTimeValue)
{
    public DateTime IssueDateTime => DateTime.ParseExact(IssueDateTimeValue, ApiSettings.ApiDateFormat, CultureInfo.InvariantCulture);
}

public record Wind(
    [property: JsonPropertyName("speed")] double Speed,
    [property: JsonPropertyName("gustSpeed")] double GustSpeed,
    [property: JsonPropertyName("trend")] int Trend,
    [property: JsonPropertyName("direction")] int Direction,
    [property: JsonPropertyName("directionText")] string DirectionText,
    [property: JsonPropertyName("id")] int Id,
    [property: JsonPropertyName("name")] string Name,
    [property: JsonPropertyName("lat")] double Lat,
    [property: JsonPropertyName("lng")] double Lng,
    [property: JsonPropertyName("distance")] double Distance
);
