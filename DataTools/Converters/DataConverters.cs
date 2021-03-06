﻿//

namespace DataTools.Converters
{
    using CoreData.APIData;
    using CoreData.GenericData;
    using CoreData.Interfaces;
    using DataToolsCore.Interfaces;

    public class DataConverters : IDataConverters

    {
        public double CelciusToFahrenHeight(double celcius)
        {
            return celcius * 9 / 5 + 32;
        }

        public double FahrenHeightToCelcius(double fahrenHeight)
        {
            return (fahrenHeight - 32) * 5 / 9;
        }

        public double MPHtoKPH(double mph)
        {
            return mph * 1.609344;
        }

        public double KPHtoMPH(double kph)
        {
            return kph / 1.609344;
        }

        public IWeatherData BBCToGeneric(BbcWeatherResult data)
        {
            return new GenericWeatherData(data.Location, data.TemperatureCelsius, data.WindSpeedKph);
        }

        public IWeatherData AccuToGeneric(AccWeatherResult data)
        {
            var celcius = FahrenHeightToCelcius(data.TemperatureFahrenheit);
            var kph = MPHtoKPH(data.WindSpeedMph);
            return new GenericWeatherData(data.Where, celcius, kph);
        }
    }
}