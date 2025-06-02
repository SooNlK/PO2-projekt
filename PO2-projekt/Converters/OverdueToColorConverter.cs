using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;

namespace PO2_projekt.Converters
{
    public class OverdueToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isOverdue && isOverdue)
                return new SolidColorBrush(Colors.MistyRose); // lub Colors.LightCoral
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 