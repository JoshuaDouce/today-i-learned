# Secrets Manager

This is a snippet of class file from [Nick Chapsas free course Cloud Fundamentals: AWS Services for C# Developers](https://nickchapsas.com/).

## DI Configuration

```C#

// By setting up our confihuration like this we do not need to include the config in appsettings as long
// a consistent naming convention is used for example
// Dev_Weather.Api_OpenWeatherMapApi__ApiKey or {env}_{appName}_{settingTopLevel}__{nestlevel1}__{nestlevel2} etc
// This will allow configuration to work out of the box and allows it to be specific to a environment & application
var env = builder.Environment.EnvironmentName;
var appName = builder.Environment.ApplicationName;

// AddSercretsManager comes from Kralizek.Extensions.Configuration.AWSSecretsManager a community package that makes
// working with aws secrets in .net easier.
builder.Configuration.AddSecretsManager(configurator: options =>
{
    options.SecretFilter = entry => entry.Name.StartsWith($"{env}_{appName}");
    options.KeyGenerator = (_, s) => s
        .Replace($"{env}_{appName}_", string.Empty)
        .Replace("__", ":");
    options.PollingInterval = TimeSpan.FromSeconds(10);
});

```

## Getting the secret value

```C#

public class WeatherService : IWeatherService
{
    private readonly IHttpClientFactory _httpClientFactory;

    // IOptionsMonitor allows us to poll the secrets value for changes by the specified interval in DI
    private readonly IOptionsMonitor<OpenWeatherApiSettings> _weatherApiOptions;

    public WeatherService(IHttpClientFactory httpClientFactory, 
        IOptionsMonitor<OpenWeatherApiSettings> weatherApiOptions)
    {
        _httpClientFactory = httpClientFactory;
        _weatherApiOptions = weatherApiOptions;
    }

    public async Task<WeatherResponse?> GetCurrentWeatherAsync(string city)
    {
        // Get secret using simple API call and by pulling the value using IOptionsMonitor
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={_weatherApiOptions.CurrentValue.ApiKey}&units=metric";
        var httpClient = _httpClientFactory.CreateClient();
        
        var weatherResponse = await httpClient.GetAsync(url);
        if (weatherResponse.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }

        var weather = await weatherResponse.Content.ReadFromJsonAsync<WeatherResponse>();
        return weather;
    }
}

```
