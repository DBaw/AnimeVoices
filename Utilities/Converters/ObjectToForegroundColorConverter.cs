using AnimeVoices.Models;
using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace AnimeVoices.Utilities.Converters
{
    public class ObjectToForegroundColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return Brushes.Transparent;

            SolidColorBrush color = new SolidColorBrush(Color.FromRgb(45, 50, 61));

            return value switch
            {
                Anime a when !string.IsNullOrEmpty(a.Title) => color,
                Character c when !string.IsNullOrEmpty(c.Name) => color,
                Result r when !string.IsNullOrEmpty(r.Character) => color,
                _ => Brushes.Transparent,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); 
        }
    }
}
