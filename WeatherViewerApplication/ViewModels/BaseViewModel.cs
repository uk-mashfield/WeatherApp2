//

namespace WeatherViewerApplication.ViewModels
{
    using System.ComponentModel;
    using Prism.Mvvm;
    using Prism.Regions;

    public abstract class BaseViewModel : BindableBase, INavigationAware
    {
        /// <summary>
        /// constant used by the <see cref="INavigationAware"/> IsNavigationTarget function to indicate this view model can be navigated to.
        /// </summary>
        protected const bool CanBeNavigationTarget = true;

        /// <summary>
        /// constant used by the <see cref="INavigationAware"/> IsNavigationTarget function to indicate this view model cannot be navigated to.
        /// </summary>
        protected const bool CannotBeNavigationTarget = false;

        /// <summary>
        /// Can this view model be used to navigate to a new view within a region.
        /// </summary>
        /// <param name="navigationContext">details of the performed navigation request.</param>
        /// <returns>true if it can be navigated to.</returns>
        public abstract bool IsNavigationTarget(
            NavigationContext navigationContext);

        /// <summary>
        /// Perform any necessary functionality (saving data etc.) when navigating from this view.
        /// </summary>
        /// <param name="navigationContext">details of the performed navigation request.</param>
        public abstract void OnNavigatedFrom(
            NavigationContext navigationContext);

        /// <summary>
        /// Perform any necessary functionality (loading data etc.) when navigating to this view.
        /// </summary>
        /// <param name="navigationContext">details of the performed navigation request.</param>
        public virtual void OnNavigatedTo(
            NavigationContext navigationContext)
        {
            NavigatedTo();
        }

        /// <summary>
        /// Load the data from the persistent data model into the view model for display.
        /// </summary>
        /// <param name="sender">Who requested the load.</param>
        /// <param name="e">What specifically changed.</param>
        protected abstract void LoadModelData(
            object sender,
            PropertyChangedEventArgs e);

        /// <summary>
        /// Load the data and set up the button bar on base of the UI
        /// </summary>
        protected void NavigatedTo()
        {
            LoadModelData(this, new PropertyChangedEventArgs(string.Empty));
        }
    }
}