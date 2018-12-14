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
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            var textBox_text = sender as TextBox;
            string text1 = textBox_text.Text;
            int itemCost = Int32.Parse(text1);
            string comboBoxText = this.CurrencySelection.Text;
            switch (comboBoxText)
            {
                case "USD":
                    const int usdExchangeRate = 140;
                    int UsdconvetToRs = itemCost * usdExchangeRate;
                    string testValue = UsdconvetToRs.ToString();
                    break;
                case "EUR":
                    const int EurExchangeRate = 140;
                    int EurconvetToRs = itemCost * EurExchangeRate;
                    testValue = EurconvetToRs.ToString();
                    break;
                
            }

            




        }



        #region HelperFunction


        #endregion

        
    }
}
