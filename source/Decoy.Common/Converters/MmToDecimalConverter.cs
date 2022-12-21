namespace Decoy.Common.Converters
{
    using System;
    using System.Windows.Data;

    public class MmToDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is decimal dec)
            {
                return dec;
            }

            if (value is string mmDecimal)
            {
                return mmDecimal.EndsWith("mm") 
                    ? System.Convert.ToDecimal(mmDecimal.Substring(0, mmDecimal.Length - 2))
                    : System.Convert.ToDecimal(mmDecimal);
            }

            return 0.0M;
        }
    }
}
