using AnimeVoices.Models;
using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace AnimeVoices.Utilities.Converters
{
    public class CharacterToForegroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Character c)
            {
                return string.IsNullOrEmpty(c.Name)
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
