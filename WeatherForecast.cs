namespace roma;



public class WeatherForecast
{
    public DateTime Date { get; set; }

    public TemperatureForecast? TemperatureForecast { get; set; }

    public string? Summary { get; set; }

    public HumidityForecast? HumidityForecast { get; set; }

    public double AtmosphericPressure { get; set;}
}
