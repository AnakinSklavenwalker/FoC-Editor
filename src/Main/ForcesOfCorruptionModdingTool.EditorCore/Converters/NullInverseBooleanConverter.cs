﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace ForcesOfCorruptionModdingTool.EditorCore.Converters
{
    public class NullInverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value != null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(bool) value)
                return null;
            return value;
        }
    }
}
