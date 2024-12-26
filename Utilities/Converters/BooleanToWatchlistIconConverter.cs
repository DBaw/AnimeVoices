using Material.Icons;
using System.Globalization;
using System;
using Avalonia.Data.Converters;

namespace AnimeVoices.Utilities.Converters
{
    public class BooleanToWatchlistIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isTrue)
            {
                return isTrue ? MaterialIconKind.Movie : MaterialIconKind.MovieOutline; // Replace with desired icons
            }
            return MaterialIconKind.QuestionMark;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
