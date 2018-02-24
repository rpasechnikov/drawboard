using System;
using System.ComponentModel;

namespace drawboard.ViewModels
{
    /// <summary>
    /// VM base class for pages
    /// </summary>
    public abstract class PageViewModelBase : INotifyPropertyChanged
    {
        public delegate void ReadyToNavigateToNextPageEventHandler(object sender, Type nextPageType);

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Allows subscribers to be notified when this page is deemed *complete* and we can navigate
        /// to next page
        /// </summary>
        public event ReadyToNavigateToNextPageEventHandler ReadyToNaviageToNextPageChanged;

        /// <summary>
        /// Raises the property changed event
        /// </summary>
        /// <param name="propertyName">Property name or null to refresh all properties for VM</param>
        protected void RaisePropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Raises the ready to navigate to next paeg event
        /// </summary>
        /// <param name="nextPageType">Type of page to navigate to</param>
        protected void RaiseReadyToNaviageToNextPageChanged(Type nextPageType)
        {
            ReadyToNaviageToNextPageChanged?.Invoke(this, nextPageType);
        }
    }
}
