using Avalonia.Data.Converters;
using Avalonia.Data;
using Avalonia.Media;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MangXp;

public class RectGeometryConverter : IValueConverter
{
  public static readonly RectGeometryConverter Instance = new();

  public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
  {
    if (value is Rect rect)
      return new RectangleGeometry(rect);

    // converter used for the wrong type
    return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
  }

  public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
  {
    if (value is RectangleGeometry rectangle)
      return rectangle.Rect;

    // converter used for the wrong type
    return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
  }

}