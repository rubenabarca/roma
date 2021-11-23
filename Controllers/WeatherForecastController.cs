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
    private static readonly Dictionary<string, TemperatureMeasurementUnit> _temperatureMeasurementUnitDictionary = 
        new Dictionary<string, TemperatureMeasurementUnit>(){
            ["alajuela"] = TemperatureMeasurementUnit.Celsius,
            ["cartago"] = TemperatureMeasurementUnit.Fahrenheit,
            ["heredia"] = TemperatureMeasurementUnit.Celsius,
            ["limon"] = TemperatureMeasurementUnit.Fahrenheit,
            ["guanacaste"] = TemperatureMeasurementUnit.Celsius,
            ["san-jose"] = TemperatureMeasurementUnit.Fahrenheit,
            ["puntarenas"] = TemperatureMeasurementUnit.Celsius,
            ["panama"] = TemperatureMeasurementUnit.Fahrenheit,
        };
    

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    private TemperatureForecast GetForecastForUnit(TemperatureMeasurementUnit unit) {
        var celsius = new TemperatureForecast(
            minimum: Random.Shared.Next(-4, 50),
            maximum: Random.Shared.Next(10, 60)
            );
        if(unit == TemperatureMeasurementUnit.Fahrenheit) {
            return celsius.ToFahrenheit();
        }
        else {
            return celsius;
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get(
        string province,
        TemperatureMeasurementUnit? unit = null
        )
    {
        province = province.ToLower();
        if(!_temperatureMeasurementUnitDictionary.ContainsKey(province)) {
            throw new InvalidOperationException($"The province {province} is not available");
        }
        var temperatureMeasurementUnit = _temperatureMeasurementUnitDictionary[province];
        if(unit != null) {
            temperatureMeasurementUnit = unit.Value;
        }
        return Enumerable.Range(1, 10).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureForecast = GetForecastForUnit(temperatureMeasurementUnit),
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
