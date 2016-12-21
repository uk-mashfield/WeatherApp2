//

namespace CoreData.Interfaces
{
    public interface IWeatherData
    {
        string Location { get; }
        double TemperatureCelsius { get; }
        double WindspeedKPH { get; }
    }
}