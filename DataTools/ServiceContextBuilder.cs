//

namespace DataTools
{
    using Converters;
    using DataHandlers;
    using DataToolsCore.Interfaces;
    using DisplayStrategy;
    using Microsoft.Practices.Unity;

    public static class ServiceContextBuilder
    {
        /// <summary>
        /// Registers services with the container
        /// </summary>
        /// <param name="container">Unity container</param>
        public static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IDataConverters, DataConverters>();
            container.RegisterType<IDataRetreival, DataRetrieval>();
            container.RegisterType<IDisplayStrategy, AverageDisplayValue>();
            container.RegisterType<IDataDeserializer, DataDeserializer>();
        }
    }
}