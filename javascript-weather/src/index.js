const BASE_URL = process.env.BASE_URL;
const WILLYWEATHER_API_KEY = process.env.WILLYWEATHER_API_KEY;
const LOCATION_ID = process.env.LOCATION_ID;

const response = await fetch(
  `${BASE_URL}/v2/${WILLYWEATHER_API_KEY}/locations/${LOCATION_ID}/weather.json?forecasts=weather&observational=true`,
  {
    headers: {
      "user-agent": "eddiegroves/hello-weather",
    },
  }
);

const weather = await response.json();

const temperature = weather.observational.observations.temperature.temperature;
const temperatureUnits = weather.observational.units.temperature;
const issueDateTime = weather.observational.issueDateTime;

console.log(
  `Temperature is ${temperature}${temperatureUnits} at ${issueDateTime}`
);
