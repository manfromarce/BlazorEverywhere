using System.Net.Http.Json;

namespace BlazorShared.Data;

public class WeatherForecastService
{
    private static readonly string[] Summaries = new[]
    {
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

    public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
    {
        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = startDate.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).ToArray());
    }
}

public class WeatherForecastServiceApi
{
    readonly IHttpClientFactory _HttpClientFactory;
    public WeatherForecastServiceApi(IHttpClientFactory http)
    {
        _HttpClientFactory = http;

    }
    public async Task<WeatherForecast[]> GetForecastAsync()
    {
        HttpClient httpclient = _HttpClientFactory.CreateClient("Test");
        var result = await httpclient.GetAsync(@"/WeatherForecast");

        var ret = await result.Content.ReadFromJsonAsync<WeatherForecast[]>();
        if (ret is null)
            throw new Exception("Could not fetch Data from WebApi");
        return ret;
    }
}
