//
namespace WeatherViewerApplication.Module
{
    using Infrastructure;
    using Prism.Modularity;
    using Prism.Regions;

    public class TopLevelModule : IModule
    {
        private readonly IRegionViewRegistry _regionViewRegistry;

        public TopLevelModule(IRegionViewRegistry regionViewRegistry)
        {
            _regionViewRegistry = regionViewRegistry;
        }

        public void Initialize()
        {
            _regionViewRegistry.RegisterViewWithRegion(Constants.ContentRegion, typeof(Views.TopLevelContent));
        }
    }
}