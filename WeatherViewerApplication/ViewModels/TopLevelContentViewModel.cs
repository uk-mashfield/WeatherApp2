//

namespace WeatherViewerApplication.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Input;
    using DataLibraryCore.Interfaces;
    using DataToolsCore.Interfaces;
    using Prism.Commands;
    using Prism.Regions;

    public class TopLevelContentViewModel : BaseViewModel, IDataErrorInfo
    {
        private readonly IWeatherAppModel _weatherAppModel;
        private readonly IDataRetreival _dataRetreival;
        private string _locationValue;
        private ICommand _dataRetrievalButtonCommand;
        private bool _dataRetrievalButtonSafeToNavigate;
        private DelegateCommand _exitCommand;
        private string _windSpeed;
        private IEnumerable<string> _windSpeedItems;
        private string _currentlySelectedWindSpeed;
        private string _temperature;
        private IEnumerable<string> _temperatureItems;
        private string _currentlySelectedTemperature;

        public TopLevelContentViewModel(IWeatherAppModel weatherAppModel, IDataRetreival dataRetreival)
        {
            _weatherAppModel = weatherAppModel;
            _dataRetreival = dataRetreival;
            DataRetrievalButtonCommand = new DelegateCommand(DataRetrievalAction, () => DataRetrievalButtonSafeToNavigate);
            ExitCommand = new DelegateCommand(ExitButtonAction, () => true);

            NavigatedTo();

            _weatherAppModel.PropertyChanged += WeatherAppModelOnPropertyChanged;
        }

        private void WeatherAppModelOnPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            WindSpeed = _weatherAppModel.DisplaySpeed.ToString();
            Temperature = _weatherAppModel.DisplayTemperature.ToString();
        }

        public override bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return CanBeNavigationTarget;
        }

        public override void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // not needed until more content pages are added.
        }

        protected override void LoadModelData(object sender, PropertyChangedEventArgs e)
        {
            WindSpeedListItems = _weatherAppModel.Speeds;
            TemperatureListItems = _weatherAppModel.Temperatures;

            CurrentlySelectedWindSpeed = WindSpeedListItems.First();
            CurrentlySelectedTemperature = TemperatureListItems.First();
        }

        private void DataRetrievalAction()
        {
            _dataRetreival.GetWeatherData(LocationValue);
        }

        public string WindSpeed
        {
            get
            {
                return _windSpeed;
            }

            set
            {
                SetProperty(ref _windSpeed, value);
            }
        }

        public IEnumerable<string> WindSpeedListItems
        {
            get
            {
                return _windSpeedItems;
            }

            set
            {
                SetProperty(ref _windSpeedItems, value);
            }
        }

        public string CurrentlySelectedWindSpeed
        {
            get
            {
                return _currentlySelectedWindSpeed;
            }

            set
            {
                SetProperty(ref _currentlySelectedWindSpeed, value);

                UpdateWindSpeed(CurrentlySelectedWindSpeed);
            }
        }

        private void UpdateWindSpeed(string currentlySelectedWindSpeed)
        {
            _weatherAppModel.CurrentSpeedType = currentlySelectedWindSpeed;
        }

        public string Temperature
        {
            get
            {
                return _temperature;
            }
            set
            {
                SetProperty(ref _temperature, value);
            }
        }

        public IEnumerable<string> TemperatureListItems
        {
            get
            {
                return _temperatureItems;
            }

            set
            {
                SetProperty(ref _temperatureItems, value);
            }
        }

        public string CurrentlySelectedTemperature
        {
            get
            {
                return _currentlySelectedTemperature;
            }

            set
            {
                SetProperty(ref _currentlySelectedTemperature, value);
                UpdateTemperature(_currentlySelectedTemperature);
            }
        }

        private void UpdateTemperature(string currentlySelectedTemperature)
        {
            _weatherAppModel.CurrentTempType = currentlySelectedTemperature;
        }

        public string LocationValue
        {
            get
            {
                return _locationValue;
            }

            set
            {
                SetProperty(ref _locationValue, value);
            }
        }

        /// <summary>
        /// Gets the validation string for errors on this page.
        /// </summary>
        public string Error { get; }

        /// <summary>
        /// Check the supplied entry is null, empty or whitespace and return true if so.
        /// </summary>
        /// <param name="entry">the string to check</param>
        /// <returns>true if invalid entry (null empty or whitespace).</returns>
        private bool InvalidEntry(string entry)
        {
            return string.IsNullOrEmpty(entry) || string.IsNullOrWhiteSpace(entry);
        }

        /// <summary>
        /// Gets any error messages associated with the supplied input control's binding name.
        /// </summary>
        /// <param name="controlName">the name of a binding to a control to validate.</param>
        /// <returns>non null string when invalid containing a message to display, null when valid.</returns>
        public string this[string controlName]
        {
            get
            {
                string result = null;
                if (controlName == "LocationControl" && InvalidEntry(LocationValue))
                {
                    result = "Please enter a valid project name.";
                }

                DataRetrievalButtonSafeToNavigate = CheckSafeToRetrieveData(result);

                return result;
            }
        }

        /// <summary>
        /// Returns a flag indicating whether it is valid to allow Data retrieval.
        /// </summary>
        /// <param name="ErrorMessage">Any potential error message being displayed.</param>
        /// <returns>a flag indicating navigation validity.</returns>
        private bool CheckSafeToRetrieveData(string ErrorMessage)
        {
            return ErrorMessage == null
                   && !string.IsNullOrEmpty(LocationValue);
        }

        /// <summary>
        /// Action performed on pressing the next key on the view.
        /// </summary>
        public ICommand DataRetrievalButtonCommand
        {
            get
            {
                return _dataRetrievalButtonCommand;
            }

            set
            {
                SetProperty(ref _dataRetrievalButtonCommand, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating if the data retrieval button is safe to be executed.
        /// </summary>
        public bool DataRetrievalButtonSafeToNavigate
        {
            get
            {
                return _dataRetrievalButtonSafeToNavigate;
            }
            set
            {
                _dataRetrievalButtonSafeToNavigate = value;

                ((DelegateCommand)DataRetrievalButtonCommand).RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Gets or sets the command attched to the exit button.
        /// </summary>
        public DelegateCommand ExitCommand
        {
            get
            {
                return _exitCommand;
            }

            set
            {
                if (value == _exitCommand)
                {
                    return;
                }

                SetProperty(ref _exitCommand, value);
            }
        }

        /// <summary>
        /// Action to perform when the operator presses the exit button on this view, as this is the first page, it is shutdown.
        /// </summary>
        protected void ExitButtonAction()
        {
            Application.Current.Shutdown();
        }
    }
}