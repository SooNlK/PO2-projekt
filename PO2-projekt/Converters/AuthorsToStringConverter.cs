using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Avalonia.Data.Converters;
using PO2_projekt.Models;

namespace PO2_projekt.Converters;

public class AuthorsToStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is IEnumerable<BookAuthor> bookAuthors)
            return string.Join(", ", bookAuthors.Select(ba => ba.Author != null ? ba.Author.FullName : ""));
        return string.Empty;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        => throw new NotImplementedException();
} 