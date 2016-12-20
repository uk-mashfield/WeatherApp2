using Microsoft.AspNetCore.Mvc;
using WeatherTest.SampleApi.Accu.Models;

namespace WeatherTest.SampleApi.Accu.Controllers
{
    public class WeatherController : Controller
    {
        private System.Random _rng = new System.Random();

        [HttpGet, Route("{where}")]
        public AccWeatherResult Get(string where)
        {
            return new AccWeatherResult {
                    Where = where,
                    TemperatureFahrenheit = _rng.Next(32, 100),
                    WindSpeedMph = _rng.Next(0, 20)
            };
        }
    }
}
