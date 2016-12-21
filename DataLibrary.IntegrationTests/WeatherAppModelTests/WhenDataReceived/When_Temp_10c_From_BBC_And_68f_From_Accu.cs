//

namespace DataLibrary.UnitTests.WeatherAppModelTests.WhenDataReceived
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category("DataTest")]
    public class When_Temp_10c_From_BBC_And_68f_From_Accu : Given_A_WeatherAppModel
    {
        private string BBC_Data = "{\"location\":\"a\",\"temperatureCelsius\":10.0,\"windSpeedKph\":8.0}";
        private string Accu_data = "{\"temperatureFahrenheit\":68.0,\"where\":\"a\",\"windSpeedMph\":15.0}";

        protected override void Because()
        {
            base.Because();
        }

        [Test]
        public void Then_Celcuis_Should_Be_15()
        {
            SUT.AddTemperatureData(10.0d);
            SUT.AddTemperatureData(DataConverters.FahrenHeightToCelcius(68.0d));

            SUT.CurrentTempType = "Celsius";

            Assert.AreEqual(15, SUT.DisplayTemperature);
        }

        [Test]
        public void Then_Fahrenheit_Should_Be_59()
        {
            SUT.AddTemperatureData(10.0d);
            SUT.AddTemperatureData(DataConverters.FahrenHeightToCelcius(68.0d));

            SUT.CurrentTempType = "Fahrenheit";

            Assert.AreEqual(59, SUT.DisplayTemperature);
        }
    }
}