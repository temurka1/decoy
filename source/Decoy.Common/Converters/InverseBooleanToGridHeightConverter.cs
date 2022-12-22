namespace Decoy.Common.Converters
{
    using System;
    using System.Windows;
    using System.Windows.Data;

    public class InverseBooleanToGridHeightConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool flag)
            {
                return !flag
                    ? new GridLength(1, GridUnitType.Star)
                    : GridLength.Auto;
            }

            return GridLength.Auto;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
