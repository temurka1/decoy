namespace Decoy.Common.Converters
{
    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    public class IndexToCornerRadiusConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is int index && values[1] is int maxIndex)
            {
                if (index == 0)
                    return new CornerRadius(3.0, 0.0, 0.0, 3.0);

                if (index == maxIndex - 1)
                    return new CornerRadius(0.0, 3.0, 3.0, 0.0);

                return new CornerRadius(0.0, 0.0, 0.0, 0.0);
            }

            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
