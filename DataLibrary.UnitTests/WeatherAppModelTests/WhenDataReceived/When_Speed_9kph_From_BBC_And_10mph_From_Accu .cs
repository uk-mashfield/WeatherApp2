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
    public class When_Speed_9kph_From_BBC_And_10mph_From_Accu : Given_A_WeatherAppModel
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

            _mockBBCWeather.WindspeedKPH.Returns(4.97d);
            _mockAccuWeather.WindspeedKPH.Returns(10d);
            MockConverters.BBCToGeneric(Arg.Any<BbcWeatherResult>()).Returns(_mockBBCWeather);
            MockConverters.AccuToGeneric(Arg.Any<AccWeatherResult>()).Returns(_mockAccuWeather);
        }

        [Test]
        public void Then_MPH_Display_Should_Use_Converter()
        {
            MockConverters.KPHtoMPH(Arg.Any<double>()).Returns(7.5);

            SUT.AddDataEntry(BBC_Data);
            SUT.AddDataEntry(Accu_data);

            SUT.CurrentSpeedType = "MPH";

            Assert.AreEqual(7.5, SUT.DisplaySpeed, 0.1);
        }

        [Test]
        public void Then_KPH_Should_Be_Direct_Display()
        {
            MockDisplayStrategy.GetDisplayValue(Arg.Any<IList<double>>()).Returns(12);

            SUT.AddDataEntry(BBC_Data);
            SUT.AddDataEntry(Accu_data);

            SUT.CurrentSpeedType = "KPH";

            Assert.AreEqual(12, SUT.DisplaySpeed);
        }
    }
}