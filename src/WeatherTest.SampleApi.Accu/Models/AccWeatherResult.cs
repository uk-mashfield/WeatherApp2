namespace WeatherTest.SampleApi.Accu.Models
{
    public class AccWeatherResult
    {
        public double TemperatureFahrenheit { get; internal set; }
        public string Where { get; internal set; }
        public double WindSpeedMph { get; internal set; }
    }
}
