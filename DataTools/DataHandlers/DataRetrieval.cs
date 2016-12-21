//

namespace DataTools.DataHandlers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Windows.Forms;
    using DataLibraryCore.Interfaces;
    using DataToolsCore.Interfaces;
    using WeatherViewerApplication.WebClient;

    public class DataRetrieval : IDataRetreival
    {
        private readonly IDataDeserializer _dataDeserializer;
        private readonly IList<string> _connectionAPIs;

        public DataRetrieval(IDataDeserializer dataDeserializer, IWeatherAppModel weatherAppModel)
        {
            _dataDeserializer = dataDeserializer;
            _connectionAPIs = weatherAppModel.ConnectionAPIs;
        }

        public void GetWeatherData(string location)
        {
            foreach (var connectionApI in _connectionAPIs)
            {
                WebClient webClient = new TimeoutWebclient();

                webClient.DownloadStringCompleted += ClientOnDownloadStringCompleted;

                webClient.DownloadStringAsync(new Uri($"{connectionApI}{location}"));
            }
        }

        private void ClientOnDownloadStringCompleted(object sender, DownloadStringCompletedEventArgs downloadStringCompletedEventArgs)
        {
            if (downloadStringCompletedEventArgs.Error != null)
            {
                // TODO add a better error handling and feedback mechanism here!
                MessageBox.Show("Could not retrieve data from site");
                return;
            }

            _dataDeserializer.AddDataEntry(downloadStringCompletedEventArgs.Result);
        }
    }
}