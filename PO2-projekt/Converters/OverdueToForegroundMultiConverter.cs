using Avalonia.Data.Converters;
using Avalonia.Media;
using System;
using System.Globalization;
using System.Collections.Generic;

namespace PO2_projekt.Converters
{
    public class OverdueToForegroundMultiConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Count > 0 && values[0] is bool isOverdue && isOverdue)
                return new SolidColorBrush(Colors.Black);
            return new SolidColorBrush(Colors.White); // domyślny kolor tekstu
        }
    }
} 