public class TemperatureForecast {
    public TemperatureMeasurementUnit Unit {get;private set;}
    public int Minimum {get;private set;}
    public int Maximum {get;private set;}
    public TemperatureForecast(
        int minimum,
        int maximum,
        TemperatureMeasurementUnit unit = TemperatureMeasurementUnit.Celsius
    ){
        Unit = unit;
        Minimum = minimum;
        Maximum = maximum;
    }
    public TemperatureForecast ToFahrenheit() {
        if(Unit == TemperatureMeasurementUnit.Fahrenheit) {
            return this;
        } else {
            return new TemperatureForecast(
                GetFarenheit(Minimum),
                GetFarenheit(Maximum),
                TemperatureMeasurementUnit.Fahrenheit
            );
        }
    }
    private int GetFarenheit(int celsiusInput) => 32 + (int)(celsiusInput / 0.5556);
}