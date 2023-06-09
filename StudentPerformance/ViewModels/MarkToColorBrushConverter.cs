﻿using Avalonia.Data.Converters;
using Avalonia.Platform;
using Avalonia;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Data;
using Avalonia.Media;

namespace StudentPerformance.ViewModels
{
    public class MarkToColorBrushConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (targetType.IsAssignableTo(typeof(IBrush)))
            {
                if(value is ushort mark)
                {
                    switch (mark)
                    {
                        case 0:
                            return new SolidColorBrush(Colors.Red);
                        case 1:
                            return new SolidColorBrush(Colors.Yellow);
                        case 2:
                            return new SolidColorBrush(Colors.Green);
                        default:
                            break;
                    }
                }
                if(value is float average)
                {
                    if (average >= 0 && average < 1) return new SolidColorBrush(Colors.Red);
                    if (average >= 1 && average < 1.5) return new SolidColorBrush(Colors.Yellow);
                    if (average >= 1.5 && average <= 2) return new SolidColorBrush(Colors.Green);
                }
            }
            return new BindingNotification(new InvalidCastException(), BindingErrorType.Error);
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

