namespace Decoy.Common.Converters
{
    using System;
    using System.Windows.Data;

    public class IntToDaysConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            if (value is int convertedDays)
            {
                return convertedDays switch
                {
                    var days when days == 0 => "-",
                    var days when days == 1 => $"{days} day",
                    _ => $"{convertedDays} days"
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
