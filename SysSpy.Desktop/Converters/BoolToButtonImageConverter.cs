using System;
using System.Globalization;
using System.Windows.Data;

namespace SysSpy.Desktop.Converters
{
    internal class BoolToButtonImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return @"..\Images\Pause.png";
            return @"..\Images\Play.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
