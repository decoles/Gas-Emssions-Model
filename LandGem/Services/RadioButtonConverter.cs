using System.Globalization;
using System.Windows.Data;

namespace LandGEM.Services
{
    public class RadioButtonConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Check if the value matches the ConverterParameter (Yes/No)
            return value != null && value.ToString().Equals(parameter.ToString(), StringComparison.OrdinalIgnoreCase);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Only update when IsChecked is TRUE
            if ((bool)value)
            {
                return parameter.ToString();
            }
            return Binding.DoNothing; // Prevents overwriting the binding when IsChecked is FALSE
        }
    }
}
