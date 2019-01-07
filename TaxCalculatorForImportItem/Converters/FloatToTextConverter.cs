using System;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace TaxCalculatorForImportItem
{
    class FloatToTextConverter : IValueConverter
    {
        public static FloatToTextConverter instance = new FloatToTextConverter();
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (String)value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            


            
            string mValue = (String)value;
            float val;
            bool check = float.TryParse(mValue, out val);
            return val;
            
        }
    }
}
