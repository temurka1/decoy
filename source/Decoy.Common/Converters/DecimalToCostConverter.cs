namespace Decoy.Common.Converters
{
    using System;
    using System.Windows.Data;

    public class DecimalToCostConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            if (value is decimal convertedCost)
            {
                return convertedCost switch
                {
                    var cost when cost == 0.0M => "-",
                    _ => $"${convertedCost:0,0.00}"
                };
            }

            return "-";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
