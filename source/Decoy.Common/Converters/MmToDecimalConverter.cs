namespace Decoy.Common.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class MmToDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is decimal dec)
            {
                return dec;
            }

            if (value is string decimalWithExtString)
            {
                var trimmedDecimalString = decimalWithExtString.TrimEnd('.', ',', 'm'); 

                if (Decimal.TryParse(trimmedDecimalString, CultureInfo.InvariantCulture, out var parsedDecimal))
                {
                    return parsedDecimal;
                }

                return default(decimal);
            }

            return value;
        }
    }
}
