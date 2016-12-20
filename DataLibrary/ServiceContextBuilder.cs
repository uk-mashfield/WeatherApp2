using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary
{
    using DataLibraryCore.Interfaces;
    using Microsoft.Practices.Unity;
    using PersistenceModel;

    public static class ServiceContextBuilder
    {
        /// <summary>
        /// Registers services with the container
        /// </summary>
        /// <param name="container">Unity container</param>
        public static void RegisterServices(IUnityContainer container)
        {
            container.RegisterType<IWeatherAppModel, WeatherAppModel>(new ContainerControlledLifetimeManager());
        }
    }
}