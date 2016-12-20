//

using System.Diagnostics.CodeAnalysis;
using BaseUnitTests;
using NUnit.Framework;
using BaseUnitTests.Generic;

namespace DataLibrary.UnitTests.WeatherAppModelTests
{
    using DataToolsCore.Interfaces;
    using NSubstitute;
    using PersistenceModel;

    [ExcludeFromCodeCoverage]
    public abstract class Given_A_WeatherAppModel : BaseUnitTestContext<WeatherAppModel>
    {
        protected IDataConverters MockConverters;
        protected IDisplayStrategy MockDisplayStrategy;

        protected override void SetContext()
        {
            MockConverters = Substitute.For<IDataConverters>();
            MockDisplayStrategy = Substitute.For<IDisplayStrategy>();

            SUT = new WeatherAppModel(MockConverters, MockDisplayStrategy);
        }
    }
}