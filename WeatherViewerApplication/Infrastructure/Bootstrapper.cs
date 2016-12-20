//

namespace WeatherViewerApplication.Infrastructure
{
    using System.Windows;
    using Microsoft.Practices.ServiceLocation;
    using Module;
    using Prism.Events;
    using Prism.Modularity;
    using Prism.Regions;
    using Prism.Unity;
    using Prism.Unity.Regions;
    using ViewModels;
    using Views;

    public class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// Setup the application required infrastructure mappings.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // defaults
            RegisterTypeIfMissing(typeof(IServiceLocator), typeof(UnityServiceLocatorAdapter), true);
            RegisterTypeIfMissing(typeof(IModuleInitializer), typeof(ModuleInitializer), true);
            RegisterTypeIfMissing(typeof(IModuleManager), typeof(ModuleManager), true);
            RegisterTypeIfMissing(typeof(RegionAdapterMappings), typeof(RegionAdapterMappings), true);
            RegisterTypeIfMissing(typeof(IRegionManager), typeof(RegionManager), true);
            RegisterTypeIfMissing(typeof(IEventAggregator), typeof(EventAggregator), true);
            RegisterTypeIfMissing(typeof(IRegionViewRegistry), typeof(RegionViewRegistry), true);
            RegisterTypeIfMissing(typeof(IRegionBehaviorFactory), typeof(RegionBehaviorFactory), true);
            RegisterTypeIfMissing(typeof(IRegionNavigationJournalEntry), typeof(RegionNavigationJournalEntry), false);
            RegisterTypeIfMissing(typeof(IRegionNavigationJournal), typeof(RegionNavigationJournal), false);
            RegisterTypeIfMissing(typeof(IRegionNavigationService), typeof(RegionNavigationService), false);
            RegisterTypeIfMissing(typeof(IRegionNavigationContentLoader), typeof(UnityRegionNavigationContentLoader), true);

            registerNavigationModels();
        }

        /// <summary>
        /// used by the in-built prism library to make the navigable regions appear (show the top level screen).
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();
            ModuleCatalog moduleCatalog = (ModuleCatalog)ModuleCatalog;
            moduleCatalog.AddModule(typeof(TitleBarModule));
            moduleCatalog.AddModule(typeof(TopLevelModule));
        }

        /// <summary>
        /// Call the registration modules in the various libraries to map together injectable types.
        /// </summary>
        protected override void ConfigureServiceLocator()
        {
            base.ConfigureServiceLocator();

            // add service context builders here
            DataLibrary.ServiceContextBuilder.RegisterServices(Container);
            DataTools.ServiceContextBuilder.RegisterServices(Container);
        }

        /// <summary>
        /// The application window.
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject CreateShell()
        {
            return Container.TryResolve<MainWindow>();
        }

        /// <summary>
        /// Display the application window.
        /// </summary>
        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// register the view models we want to make navigable.
        /// </summary>
        private void registerNavigationModels()
        {
            // add VMs here if we want model first architecture..
            Container.RegisterTypeForNavigation<TopLevelContentViewModel>();
        }
    }
}