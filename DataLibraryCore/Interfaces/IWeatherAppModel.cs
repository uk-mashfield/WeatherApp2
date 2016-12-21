//

namespace DataLibraryCore.Interfaces
{
    using System.Collections.Generic;

    public interface IWeatherAppModel : IBaseModel
    {
        void AddSpeedData(double windSpeed);

        void AddTemperatureData(double temp);

        IList<string> ConnectionAPIs { get; }

        IList<string> Temperatures { get; }
        IList<string> Speeds { get; }

        double DisplaySpeed { get; }

        double DisplayTemperature { get; }

        string CurrentSpeedType { get; set; }
        string CurrentTempType { get; set; }
    }
}