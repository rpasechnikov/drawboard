using System.ComponentModel;

namespace drawboard.ViewModels
{
    /// <summary>
    /// Base VM
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Raises the property changed event
        /// </summary>
        /// <param name="propertyName">Property name or null to refresh all properties for VM</param>
        protected void RaisePropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
