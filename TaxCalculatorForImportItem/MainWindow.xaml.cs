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
             
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BaseViewModel assesedValue = new BaseViewModel()
                { AssesedValue = GetNewValue()};
                assesedValue.TotalTax = GetTotalTax(assesedValue.AssesedValue);
                assesedValue.GrandTotal = GetGrandTotal(assesedValue.AssesedValue, assesedValue.TotalTax);
                this.CalculatedValue.Text = assesedValue.AssesedValue;
                this.totaltax.Text = assesedValue.TotalTax;
                this.grandtotal.Text = assesedValue.GrandTotal;

            }
            catch (Exception )
            {
                throw;
                
            }
            
        }

        private string GetGrandTotal(string assesedValue, string totalTax)
        {
            float val, val1;
            bool value = float.TryParse(assesedValue, out val);
            bool value2 = float.TryParse(totalTax, out val1);
            return (val+val1).ToString();
        }


        private string GetTotalTax()
        {
            BaseViewModel baseView = new BaseViewModel();
            float value;
            bool nvalue = float.TryParse(baseView.AssesedValue, out value);
            float nAcd, nCd, nSt, nIt;
            nAcd = float.Parse(this.ACD.Text) / 100;
            nCd = float.Parse(this.CD.Text) / 100;
            nSt = float.Parse(this.ST.Text) / 100;
            nIt = float.Parse(this.IT.Text) / 100;

            nAcd = (value) * nAcd;
            nCd = (value) * nCd;

            float sum = nCd + nAcd;

            nSt = sum * nSt;
            sum = sum + nSt;
            nIt = sum * nIt;
            sum = sum + nIt;

            return (String)sum.ToString();
        }



        private string GetTotalTax(string value)
        {
            float nAcd, nCd, nSt, nIt;
            nAcd = float.Parse(this.ACD.Text)/100;
            nCd = float.Parse(this.CD.Text)/100;
            nSt = float.Parse(this.ST.Text)/100;
            nIt = float.Parse(this.IT.Text)/100;

            nAcd = float.Parse(value) * nAcd;
            nCd  = float.Parse(value) * nCd;

            float sum =nCd + nAcd;

            nSt = sum * nSt;
            sum = sum + nSt;
            nIt = sum* nIt;
            sum = sum + nIt;

            return (String)sum.ToString();
        }

        #region HelperFunction

        private string GetNewValue()
        {
            //Assesed Value Calculation

            float assesedValue = float.Parse(this.ItemCost.Text);
            float currencyTolerance = float.Parse(this.CurrencyTolerance.Text);
            float insuranceValue = float.Parse(this.Insurance.Text);

            string currType = this.CurrencySelection.SelectedItem.ToString();

            if (currType.Contains("USD"))
            {
                float value = GetAnswer((Int32)CurrencyValue.USD, assesedValue, currencyTolerance, insuranceValue);
                return (String)(value).ToString();
                
            }

            else if (currType.Contains("EUR"))
            {
                float value = GetAnswer((Int32)CurrencyValue.EUR, assesedValue, currencyTolerance, insuranceValue);
                return (String)(value).ToString();
                
            }

            else if (currType.Contains("GBP"))
            {

                float value = GetAnswer((Int32)CurrencyValue.GBP, assesedValue, currencyTolerance, insuranceValue);
                return (String)(value).ToString();
            }

            else if (currType.Contains("YUAN"))
            {
                float value = GetAnswer((Int32)CurrencyValue.YUAN, assesedValue, currencyTolerance, insuranceValue);
                return (String)(value).ToString();
            }

            else if (currType.Contains("Rs"))
            {
                float value = GetAnswer((Int32)CurrencyValue.RS,assesedValue,currencyTolerance,insuranceValue);
                return (String)(value).ToString();
            }
            else
                return "problem";
        }

        /// <summary>
        /// Assesed Value calculation   
        /// </summary>
        /// <param name="rS">currencyValue</param>
        /// <param name="assesedValue">BaseObject</param>
        /// <param name="currencyTolerance">currencyChangePercentage</param>
        /// <param name="insuranceValue">InsurancePercentage</param>
        /// <returns></returns>
        private float GetAnswer(int rS, float assesedValue, float currencyTolerance, float insuranceValue)
        {
            float value = assesedValue * rS;
            value = value + value * (currencyTolerance / 100);
            value = value + value * (insuranceValue / 100);
            return value;
        }

        #endregion
    }

}
