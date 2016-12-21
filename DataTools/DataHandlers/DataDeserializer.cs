//

namespace DataTools.DataHandlers
{
    using CoreData.APIData;
    using CoreData.Interfaces;
    using DataLibraryCore.Interfaces;
    using DataToolsCore.Interfaces;
    using Newtonsoft.Json;

    public class DataDeserializer : IDataDeserializer
    {
        private readonly IWeatherAppModel _weatherAppModel;
        private readonly IDataConverters _dataConverters;

        public DataDeserializer(IWeatherAppModel weatherAppModel, IDataConverters dataConverters)
        {
            _weatherAppModel = weatherAppModel;
            _dataConverters = dataConverters;
        }

        public void AddDataEntry(string data)
        {
            // I really do not like this, if I get time I will return and do something better... #sloppy
            IWeatherData genericData = null;

            if (data.Contains("location"))
            {
                // BBC
                var results = JsonConvert.DeserializeObject<BbcWeatherResult>(data);
                genericData = _dataConverters.BBCToGeneric(results);
            }
            else if (data.Contains("where"))
            {
                //ACCu
                var results = JsonConvert.DeserializeObject<AccWeatherResult>(data);
                genericData = _dataConverters.AccuToGeneric(results);
            }

            if (genericData != null)
            {
                _weatherAppModel.AddSpeedData(genericData.WindspeedKPH);
                _weatherAppModel.AddTemperatureData(genericData.TemperatureCelsius);
            }
        }
    }
}