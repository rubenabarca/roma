using Microsoft.AspNetCore.Mvc;

namespace roma.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 10).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureForecast = new TemperatureForecast() {
                Minimum = Random.Shared.Next(-4, 50),
                Maximum = Random.Shared.Next(10, 60)
            },
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            HumidityForecast = new HumidityForecast(){
                Minimum = Random.Shared.Next (0,50),
                Maximum = Random.Shared.Next (50,100)
            },
            AtmosphericPressure = Random.Shared.Next (1,50),
        })
        .ToArray();
    }
}
