using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace AnimeVoices.Utilities.Converters
{
    public class BooleanToListHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isTrue)
            {
                return isTrue ? 510 : 0; // Replace with max list heigh
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
