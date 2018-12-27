using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaxCalculatorForImportItem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new BaseViewModel();
        }

        private void CurrencySelection_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BaseViewModel assesedValue = new BaseViewModel() { AssesedValue = GetNewValue() };
            this.CalculatedValue.Text= assesedValue.AssesedValue;
        }

        private string GetNewValue()
        {
            //Assesed Value Calculation
            int assesedValue;
            bool inputCost = int.TryParse(this.ItemCost.Text,out assesedValue);


            float currencyTolerance = float.Parse(this.CurrencyTolerance.Text);


            float insuranceValue = float.Parse(this.Insurance.Text);
            


            string currType =this.CurrencySelection.SelectedItem.ToString();
            if (currType.Contains("USD"))
            {

                int usd = (Int32)CurrencyValue.USD;
                int value = assesedValue * usd;
                float Nvalue =value+value * (currencyTolerance/100);
                float result =Nvalue+Nvalue * (insuranceValue / 100);
                return (String)(result).ToString();
            }

            else if (currType.Contains("EUR"))
            {

                int eur = (Int32)CurrencyValue.EUR;
                int value = assesedValue * eur;
                float Nvalue = value + value * (currencyTolerance / 100);
                float result = Nvalue + Nvalue * (insuranceValue / 100);
                return (String)(result).ToString();
            }

            else if (currType.Contains("GBP"))
            {

                int pound = (Int32)CurrencyValue.GBP;
                int value = assesedValue * pound;
                float Nvalue = value + value * (currencyTolerance / 100);
                float result = Nvalue + Nvalue * (insuranceValue / 100);
                return (String)(result).ToString();
            }

            else if (currType.Contains("YUAN"))
            {

                int yuan = (Int32)CurrencyValue.YUAN;
                int value = assesedValue * yuan;
                float Nvalue = value + value * (currencyTolerance / 100);
                float result = Nvalue + Nvalue * (insuranceValue / 100);
                return (String)(result).ToString();
            }

            else if (currType.Contains("Rs"))
            {

                int rs = (Int32)CurrencyValue.RS;
                int value = assesedValue * rs;
                float Nvalue = value + value * (currencyTolerance / 100);
                float result = Nvalue + Nvalue * (insuranceValue / 100);
                return (String)(result).ToString();
            }
            else
                return "problem";

        }
    }

}
