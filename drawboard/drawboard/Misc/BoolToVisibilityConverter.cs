using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace drawboard.Misc
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        private Visibility visible = Visibility.Visible;
        private Visibility collapsed = Visibility.Collapsed;

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if ((bool)value)
            {
                return visible;
            }

            return collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            if (value.Equals(visible))
            {
                return true;
            }

            return false;
        }
    }
}
