//

namespace DataLibrary.PersistenceModel
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CoreData.APIData;
    using CoreData.Interfaces;
    using DataLibraryCore.Interfaces;
    using DataToolsCore.Interfaces;
    using Newtonsoft.Json;

    public class WeatherAppModel : BaseModel, IWeatherAppModel
    {
        private readonly IDataConverters _dataConverters;
        private readonly IDisplayStrategy _displayStrategy;
        private readonly IList<string> _connectionAPIs;
        private readonly IList<string> _temperatures;
        private readonly IList<string> _speeds;
        private readonly IList<double> _speedData;
        private readonly IList<double> _temperatureData;

        private readonly IDictionary<string, Func<double, double>> _displayConverters;

        private double _displaySpeed;
        private double _displayTemperature;
        private string _currentSpeedType;
        private string _currentTempType;

        private const string MPH = "MPH";
        private const string KPH = "KPH";
        private const string Celsius = "Celsius";
        private const string Fahrenheit = "Fahrenheit";

        public WeatherAppModel(IDataConverters dataConverters, IDisplayStrategy displayStrategy)
        {
            _dataConverters = dataConverters;
            _displayStrategy = displayStrategy;
            _connectionAPIs = new List<string>
            {
                "http://localhost:60350/Weather/",
                "http://localhost:60368/"
            };

            _speeds = new List<string>
            {
                MPH,
                KPH
            };

            _temperatures = new List<string>
            {
                Celsius,
                Fahrenheit
            };

            _displayConverters = new Dictionary<string, Func<double, double>>
            {
                {MPH, d => _dataConverters.KPHtoMPH(d)},
                {Fahrenheit, d => _dataConverters.CelciusToFahrenHeight(d)}
            };

            _speedData = new List<double>();
            _temperatureData = new List<double>();

            _currentSpeedType = _speeds.First();
            _currentTempType = _temperatures.First();
        }

        public void AddDataEntry(string data)
        {
            // I really do not like this, if I get time I will return and do something better... #sloppy
            IWeatherData genericData = null;

            if (data.Contains("location"))
            {
                // BBC
                BbcWeatherResult results = JsonConvert.DeserializeObject<BbcWeatherResult>(data);
                genericData = _dataConverters.BBCToGeneric(results);
            }
            else if (data.Contains("where"))
            {
                //ACCu
                AccWeatherResult results = JsonConvert.DeserializeObject<AccWeatherResult>(data);
                genericData = _dataConverters.AccuToGeneric(results);
            }

            if (genericData != null)
            {
                _speedData.Add(genericData.WindspeedKPH);
                _temperatureData.Add(genericData.TemperatureCelsius);

                updateCurrentSpeed();
                updateCurrentTemp();
            }
        }

        private void updateCurrentSpeed()
        {
            var speed = _displayStrategy.GetDisplayValue(_speedData);

            DisplaySpeed = _displayConverters.ContainsKey(CurrentSpeedType) ? _displayConverters[CurrentSpeedType](speed) : speed;
        }

        private void updateCurrentTemp()
        {
            var temp = _displayStrategy.GetDisplayValue(_temperatureData);
            DisplayTemperature = _displayConverters.ContainsKey(CurrentTempType) ? _displayConverters[CurrentTempType](temp) : temp;
        }

        public IList<string> ConnectionAPIs
        {
            get
            {
                return _connectionAPIs;
            }
        }

        public IList<string> Temperatures
        {
            get
            {
                return _temperatures;
            }
        }

        public IList<string> Speeds
        {
            get
            {
                return _speeds;
            }
        }

        public double DisplaySpeed
        {
            get
            {
                return _displaySpeed;
            }

            private set
            {
                _displaySpeed = value;
                OnPropertyChanged(nameof(DisplaySpeed));
            }
        }

        public double DisplayTemperature
        {
            get
            {
                return _displayTemperature;
            }
            private set
            {
                _displayTemperature = value;
                OnPropertyChanged(nameof(DisplayTemperature));
            }
        }

        public string CurrentSpeedType
        {
            get
            {
                return _currentSpeedType;
            }
            set
            {
                _currentSpeedType = value;
                updateCurrentSpeed();
            }
        }

        public string CurrentTempType
        {
            get
            {
                return _currentTempType;
            }
            set
            {
                _currentTempType = value;
                updateCurrentTemp();
            }
        }
    }
}