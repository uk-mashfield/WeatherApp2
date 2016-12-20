//
namespace WeatherViewerApplication.Module
{
    using Infrastructure;
    using Prism.Modularity;
    using Prism.Regions;
    using Views;

    /// <summary>
    /// Prism navigation region for the application title bar region
    /// </summary>
    public class TitleBarModule : IModule
    {
        /// <summary>
        /// Region registry
        /// </summary>
        private readonly IRegionViewRegistry _regionViewRegistry;

        /// <summary>
        /// Initialises a new instance of the <see cref="TitleBarModule"/> class.
        /// </summary>
        /// <param name="regionViewRegistry"></param>
        public TitleBarModule(IRegionViewRegistry regionViewRegistry)
        {
            _regionViewRegistry = regionViewRegistry;
        }

        /// <summary>
        /// Initialize function as per the module interface implementation.
        /// </summary>
        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion(Constants.TitleRegion, typeof(TitleBar));
        }
    }
}