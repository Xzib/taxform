using Prism.Commands;
using PropertyChanged;
using System;
using System.ComponentModel;
using System.Windows.Controls;

namespace TaxCalculatorForImportItem
{

    [ImplementPropertyChanged]
    class BaseViewModel : INotifyPropertyChanged
    {
        #region Public Event Handler

        /// <summary>
        /// public eventHandler
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        #endregion

        #region Constructor

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BaseViewModel()
        {
            this.OKButtonPressed = new DelegateCommand(GetAnswer);
        }

        #endregion



        #region Public Properties
        /// <summary>
        /// Actual Cost of the item
        /// </summary>
        public float ItemCost { get; set; } = 0;

        /// <summary>
        /// Currenct Tolerance set to 1% initial
        /// </summary>
        public float CurrencyTolerancePercentage { get; set; } = 1;

        /// <summary>
        /// Insurance value set to 1% initial
        /// </summary>
        public float InsurancePercentage { get; set; } = 1;

        /// <summary>
        /// Actual Value of item 
        /// </summary>
        public string AssesedValue { get; set; } = "Assesed Value";

        /// <summary>
        /// Total Tax on the item
        /// </summary>
        public string TotalTax { get; set; }

        /// <summary>
        /// Grand Total
        /// </summary>
        public string GrandTotal { get; set; }

        #region Currency Model

        public String AvailableCurrency { get; set; }


        /// <summary>
        /// Currency Rates
        /// </summary>
        public float UsdExchangeRate { get; set; } = 140;
        public float EuroExchangeRate { get; set; } = 160;
        public float GBPExchangeRate { get; set; } = 170;

        #endregion


        #endregion

        #region Commands

        public DelegateCommand OKButtonPressed { get; set; }

        #endregion

        #region HelperFunctions

        /// <summary>
        /// Calculation of Assesed Value
        /// </summary>
        /// <param name="exchangeRate">Currency Exchange Rate</param>
        /// <param name="ItemCost">Actual Cost of the item</param>
        /// <param name="currencyTolerance">percent change in currency</param>
        /// <param name="insuranceValue">user input</param>
        /// <returns></returns>
        private void GetAnswer()
        {

            float value = ItemCost * UsdExchangeRate;
            value = value + value * (CurrencyTolerancePercentage / 100);
            value = value + value * (InsurancePercentage / 100);
            AssesedValue = (String)value.ToString();
        }

        #endregion



    }
}
