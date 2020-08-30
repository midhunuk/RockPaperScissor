using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace RPSGUI.Converter
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public bool IsInverted { get; set; }

        public bool IsCollapsed { get; set; }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(!(value is bool))
            {
                throw new ArgumentException("Argument is not boolean type");
            }

            var input = IsInverted ? !(bool)value : (bool)value;

            if(input)
            {
                return Visibility.Visible;
            }
            else
            {
                return IsCollapsed ? Visibility.Collapsed : Visibility.Hidden;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
