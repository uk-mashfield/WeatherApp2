//

namespace DataLibrary.UnitTests.WeatherAppModelTests.WhenDataReceived
{
    using System.Diagnostics.CodeAnalysis;
    using DataTools.Converters;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category("DataTest")]
    public class When_Speed_8kph_From_BBC_And_10mph_From_Accu : Given_A_WeatherAppModel
    {
        [Test]
        public void Then_MPH_Should_Be_7_Point_5()
        {
            SUT.AddSpeedData(8.0d);
            SUT.AddSpeedData(DataConverters.MPHtoKPH(10.0d));

            SUT.CurrentSpeedType = "MPH";

            Assert.AreEqual(7.5, SUT.DisplaySpeed, 0.1);
        }

        [Test]
        public void Then_KPH_Should_Be_12()
        {
            SUT.AddSpeedData(8.0d);
            SUT.AddSpeedData(DataConverters.MPHtoKPH(10.0d));

            SUT.CurrentSpeedType = "KPH";

            Assert.AreEqual(12, SUT.DisplaySpeed, 0.1);
        }
    }
}