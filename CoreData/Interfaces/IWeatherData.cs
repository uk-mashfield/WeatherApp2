//

namespace CoreData.Interfaces
{
    public interface IWeatherData
    {
        string Location { get; }
        double TemperatureCelsius { get; }
        double WindspeedMPH { get; }
    }
}