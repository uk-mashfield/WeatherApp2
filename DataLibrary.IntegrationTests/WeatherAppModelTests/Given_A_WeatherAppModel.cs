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
        protected DataConverters DataConverters;

        protected override void SetContext()
        {
            DataConverters = new DataConverters();

            var displayStrategy = new AverageDisplayValue();

            SUT = new WeatherAppModel(DataConverters, displayStrategy);
        }
    }
}