using System.Text.Json;

var BASE_URL = Environment.GetEnvironmentVariable("BASE_URL");
var WILLYWEATHER_API_KEY = Environment.GetEnvironmentVariable("WILLYWEATHER_API_KEY");
var LOCATION_ID = Environment.GetEnvironmentVariable("LOCATION_ID");

using HttpClient client = new();
client.DefaultRequestHeaders.Add("user-agent", "eddiegroves/hello-weather");

var json = await client.GetStringAsync($"{BASE_URL}/v2/{WILLYWEATHER_API_KEY}/locations/{LOCATION_ID}/weather.json?forecasts=weather&observational=true");
var weather = JsonSerializer.Deserialize<WeatherByLocation>(json);

var temperature = weather?.Observational.Observations.Temperature.TemperatureValue;
var temperatureUnits = weather?.Observational.Units.Temperature;
var issueDateTime = weather?.Observational.IssueDateTime;

Console.WriteLine($"Temperature is {temperature}{temperatureUnits} at {issueDateTime}");
