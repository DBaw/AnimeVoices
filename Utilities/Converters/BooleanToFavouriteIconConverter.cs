using Avalonia.Data.Converters;
using Material.Icons;
using System;
using System.Globalization;

namespace AnimeVoices.Utilities.Converters
{
    public class BooleanToFavouriteIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isTrue)
            {
                return isTrue ? MaterialIconKind.Heart : MaterialIconKind.HeartOutline; // Replace with desired icons
            }
            return MaterialIconKind.QuestionMark;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
