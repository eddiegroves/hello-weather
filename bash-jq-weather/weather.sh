SCRIPTPATH=$(dirname "$(realpath "$0")")
curl --silent --show-error "$BASE_URL/v2/$WILLYWEATHER_API_KEY/locations/$LOCATION_ID/weather.json?forecasts=weather&observational=true" | \
    gojq -f "$SCRIPTPATH/weather.jq"
