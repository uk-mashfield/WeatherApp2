//

namespace DataLibrary.UnitTests.WeatherAppModelTests
{
    using System.Diagnostics.CodeAnalysis;
    using BaseUnitTests.Generic;
    using DataTools.Converters;
    using DataTools.DisplayStrategy;
    using PersistenceModel;

    [ExcludeFromCodeCoverage]
    public abstract class Given_A_WeatherAppModel : BaseUnitTestContext<WeatherAppModel>
    {
        protected override void SetContext()
        {
            var dataConverters = new DataConverters();
            var displayStrategy = new AverageDisplayValue();

            SUT = new WeatherAppModel(dataConverters, displayStrategy);
        }
    }
}