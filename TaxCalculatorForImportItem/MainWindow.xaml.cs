using System;
using System.Windows;
using System.Windows.Controls;


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

            float assesedValue = float.Parse(this.ItemCost.Text);
            float currencyTolerance = float.Parse(this.CurrencyTolerance.Text);
            float insuranceValue = float.Parse(this.Insurance.Text);
            
            string currType =this.CurrencySelection.SelectedItem.ToString();

            if (currType.Contains("USD"))
            {
                float usd = (Int32)CurrencyValue.USD;
                float value = assesedValue * usd;
                value = value + value * (currencyTolerance / 100);
                value = value + value * (insuranceValue / 100);
                return (String)(value).ToString();
            }

            else if (currType.Contains("EUR"))
            {
                float eur = (Int32)CurrencyValue.EUR;
                float value = assesedValue * eur;
                value = value + value * (currencyTolerance / 100);
                value = value + value * (insuranceValue / 100);
                return (String)(value).ToString();
            }

            else if (currType.Contains("GBP"))
            {

                float pound = (Int32)CurrencyValue.GBP;
                float value = assesedValue * pound;
                value = value + value * (currencyTolerance / 100);
                value = value + value * (insuranceValue / 100);
                return (String)(value).ToString();
            }

            else if (currType.Contains("YUAN"))
            {
                float yuan = (Int32)CurrencyValue.YUAN;
                float value = assesedValue * yuan;
                value = value + value * (currencyTolerance / 100);
                value = value + value * (insuranceValue / 100);
                return (String)(value).ToString();
            }

            else if (currType.Contains("Rs"))
            {
                float rs = (Int32)CurrencyValue.RS;
                float value = assesedValue * rs;
                value = value + value * (currencyTolerance / 100);
                value = value + value * (insuranceValue / 100);
                return (String)(value).ToString();
            }
            else
                return "problem";
        }
    }

}
