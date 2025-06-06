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
            // Obsługa MultiBinding z ConverterParameter
            if (parameter is string param && param == "foreground")
            {
                if (value is bool isOverdue && isOverdue)
                    return new SolidColorBrush(Colors.Black);
                return new SolidColorBrush(Colors.White); // domyślny kolor tekstu
            }
            // Domyślnie tło
            if (value is bool isOverdueBg && isOverdueBg)
                return new SolidColorBrush(Colors.LightSkyBlue); // lub Colors.LightCoral
            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 