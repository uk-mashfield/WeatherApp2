//

namespace WeatherViewerApplication.WebClient
{
    using System;
    using System.Net;

    public class TimeoutWebclient : WebClient
    {
        // SpecifiedTimeout in milliseconds, default = 3,000 msec
        public int SpecifiedTimeout { get; set; }

        public TimeoutWebclient()
        {
            SpecifiedTimeout = 3000;
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var objWebRequest = base.GetWebRequest(address);
            objWebRequest.Timeout = SpecifiedTimeout;
            return objWebRequest;
        }
    }
}