//

namespace DataLibrary.UnitTests.WeatherAppModelTests.WhenDataReceived
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using CoreData.APIData;
    using CoreData.GenericData;
    using CoreData.Interfaces;
    using NSubstitute;
    using NUnit.Framework;

    [TestFixture]
    [ExcludeFromCodeCoverage]
    [Category("DataTest")]
    public class When_Temp_10c_From_BBC_And_68f_From_Accu : Given_A_WeatherAppModel
    {
        private string BBC_Data = "{\"location\":\"a\",\"temperatureCelsius\":10.0,\"windSpeedKph\":8.0}";
        private string Accu_data = "{\"temperatureFahrenheit\":68.0,\"where\":\"a\",\"windSpeedMph\":15.0}";

        private IWeatherData _mockBBCWeather;
        private IWeatherData _mockAccuWeather;

        protected override void Because()
        {
            base.Because();
            _mockBBCWeather = Substitute.For<IWeatherData>();
            _mockAccuWeather = Substitute.For<IWeatherData>();

            _mockBBCWeather.TemperatureCelsius.Returns(10d);
            _mockAccuWeather.TemperatureCelsius.Returns(20d);
            MockConverters.BBCToGeneric(Arg.Any<BbcWeatherResult>()).Returns(_mockBBCWeather);
            MockConverters.AccuToGeneric(Arg.Any<AccWeatherResult>()).Returns(_mockAccuWeather);
        }

        [Test]
        public void Then_Celcuis_Should_Be_15()
        {
            MockDisplayStrategy.GetDisplayValue(Arg.Any<IList<double>>()).Returns(15);

            SUT.AddDataEntry(BBC_Data);
            SUT.AddDataEntry(Accu_data);

            SUT.CurrentTempType = "Celsius";

            Assert.AreEqual(15, SUT.DisplayTemperature);
        }

        [Test]
        public void Then_Fahrenheit_Should_Be_59()
        {
            MockConverters.CelciusToFahrenHeight(Arg.Any<double>()).Returns(59);

            SUT.AddDataEntry(BBC_Data);
            SUT.AddDataEntry(Accu_data);

            SUT.CurrentTempType = "Fahrenheit";

            Assert.AreEqual(59, SUT.DisplayTemperature);
        }
    }
}