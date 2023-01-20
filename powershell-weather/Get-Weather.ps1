$BASE_URL = $env:BASE_URL
$WILLYWEATHER_API_KEY = $env:WILLYWEATHER_API_KEY
$LOCATION_ID = $env:LOCATION_ID

$weather = Invoke-RestMethod -Uri "$BASE_URL/v2/$WILLYWEATHER_API_KEY/locations/$LOCATION_ID/weather.json?forecasts=weather&observational=true"

$temperature = $weather.Observational.Observations.Temperature.Temperature
$temperatureUnits = $weather.Observational.Units.Temperature
$issueDateTime = $weather.Observational.IssueDateTime

"Temperature is $temperature$temperatureUnits at $issueDateTime"
