//

namespace DataLibrary.UnitTests.WeatherAppModelTests.WhenDataReceived
{
    using System.Diagnostics.CodeAnalysis;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category("DataTest")]
    public class When_Speed_8kph_From_BBC_And_10mph_From_Accu : Given_A_WeatherAppModel
    {
        private readonly string BBC_Data = "{\"location\":\"a\",\"temperatureCelsius\":10.0,\"windSpeedKph\":8.0}";
        private readonly string Accu_data = "{\"temperatureFahrenheit\":68.0,\"where\":\"a\",\"windSpeedMph\":10.0}";

        protected override void Because()
        {
            base.Because();
        }

        [Test]
        public void Then_MPH_Should_Be_7_Point_5()
        {
            SUT.AddDataEntry(BBC_Data);
            SUT.AddDataEntry(Accu_data);

            SUT.CurrentSpeedType = "MPH";

            Assert.AreEqual(7.5, SUT.DisplaySpeed, 0.1);
        }

        [Test]
        public void Then_KPH_Should_Be_12()
        {
            SUT.AddDataEntry(BBC_Data);
            SUT.AddDataEntry(Accu_data);

            SUT.CurrentSpeedType = "KPH";

            Assert.AreEqual(12, SUT.DisplaySpeed, 0.1);
        }
    }
}