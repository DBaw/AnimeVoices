using AnimeVoices.Models;
using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace AnimeVoices.Utilities.Converters
{
    public class AnimeToForegroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Anime a)
            {
                return string.IsNullOrEmpty(a.Title)
                    ? Brushes.Transparent
                    : new SolidColorBrush(Color.FromRgb(45, 50, 61));
            }
            return Brushes.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
