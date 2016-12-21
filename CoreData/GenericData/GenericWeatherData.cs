//

namespace CoreData.GenericData
{
    using Interfaces;

    public class GenericWeatherData : IWeatherData
    {
        public GenericWeatherData(string location, double temperature, double speed)
        {
            Location = location;
            TemperatureCelsius = temperature;
            WindspeedKPH = speed;
        }

        public string Location { get; }
        public double TemperatureCelsius { get; }
        public double WindspeedKPH { get; }
    }
}