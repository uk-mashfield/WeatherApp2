namespace DataToolsCore.Interfaces
{
    using CoreData.APIData;
    using CoreData.GenericData;
    using CoreData.Interfaces;

    public interface IDataConverters
    {
        double CelciusToFahrenHeight(double celcius);

        double FahrenHeightToCelcius(double fahrenHeight);

        double MPHtoKPH(double mph);

        double KPHtoMPH(double kph);

        IWeatherData BBCToGeneric(BbcWeatherResult data);

        IWeatherData AccuToGeneric(AccWeatherResult data);
    }
}