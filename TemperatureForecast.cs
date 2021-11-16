public class TemperatureForecast {
    public int Minimum {get;set;}

    public int MinimumF => GetFarenheit(Minimum);
    public int Maximum {get;set;}

    public int MaximumF => GetFarenheit(Maximum);

    private int GetFarenheit(int celsiusInput) => 32 + (int)(celsiusInput / 0.5556);

    
}