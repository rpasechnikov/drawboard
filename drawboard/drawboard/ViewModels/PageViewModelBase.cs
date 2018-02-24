using System;
using System.ComponentModel;

namespace drawboard.ViewModels
{
    /// <summary>
    /// Base VM for pages
    /// </summary>
    public abstract class PageViewModelBase : ViewModelBase
    {
        public delegate void ReadyToNavigateToNextPageEventHandler(object sender, Type nextPageType);

        /// <summary>
        /// Allows subscribers to be notified when this page is deemed *complete* and we can navigate
        /// to next page
        /// </summary>
        public event ReadyToNavigateToNextPageEventHandler ReadyToNaviageToNextPageChanged;

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
