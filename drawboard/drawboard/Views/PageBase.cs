using drawboard.ViewModels;
using System;
using Windows.UI.Xaml.Controls;

namespace drawboard.Views
{
    /// <summary>
    /// Base page class that is able to navigate from page to page automatically
    /// </summary>
    public class PageBase : Page
    {
        public PageBase()
        {
            Loaded += PageBase_Loaded;
        }

        /// <summary>
        /// Hook up to <see cref="PageViewModelBase.ReadyToNaviageToNextPageChanged"/> if possible
        /// </summary>
        private void PageBase_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var pageViewModelBase = DataContext as PageViewModelBase;

            if (pageViewModelBase != null)
            {
                // Clunky... probably need an IoC container to add page navigation service or something along
                // those lines
                pageViewModelBase.ReadyToNaviageToNextPageChanged += NavigateToNextPage;
            }
        }

        /// <summary>
        /// Navigate to next page once we get notified that VM is done with the current page
        /// </summary>
        private void NavigateToNextPage(object sender, Type nextPageType)
        {
            try
            {
                Frame.Navigate(nextPageType);
            }
            catch
            {
                // Probably log this/warn the user/etc...
            }
        }
    }
}
