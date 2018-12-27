using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace TaxCalculatorForImportItem
{
    class StringToTextBoxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (TextBox)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
