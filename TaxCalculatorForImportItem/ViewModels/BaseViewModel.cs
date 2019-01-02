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
            this.OKButtonPressedCommand = new DelegateCommand(this.GetGrandTotal);
        }

        #endregion

        #region Public Properties
        /// <summary>
        /// Actual Cost of the item
        /// </summary>
        public float ItemCost { get; set; } = 0;

        #region PercentageInputs
        
        /// <summary>
        /// Currenct Tolerance set to 1% initial
        /// </summary>
        public float CurrencyTolerancePercentage { get; set; } = 1;

        /// <summary>
        /// Insurance value set to 1% initial
        /// </summary>
        public float InsurancePercentage { get; set; } = 1;

        /// <summary>
        /// ACD set to 2%
        /// </summary>
        public float ACD { get; set; } = 2;
        
        /// <summary>
        /// CustomDuty set to 20%
        /// </summary>
        public float CD { get; set; } = 20;

        /// <summary>
        /// Sales TAX is set  to 17%
        /// </summary>
        public float ST { get; set; } = 17;

        /// <summary>
        /// Income tax Is set to 9%
        /// </summary>
        public float IT { get; set; } = 9;

        #endregion

        /// <summary>
        /// Actual Value of item 
        /// </summary>
        public string AssesedValue { get; set; } = "0";

        /// <summary>
        /// Total Tax on the item
        /// </summary>
        public string TotalTax { get; set; } = "0";

        /// <summary>
        /// Grand Total
        /// </summary>
        public string GrandTotal { get; set; } = "0";

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

        public DelegateCommand OKButtonPressedCommand { get; set; }

        #endregion

        #region HelperFunctions

        /// <summary>
        /// Grand Total Calculation
        /// </summary>
        private void GetGrandTotal()
        {

            GetTotalTax();
            float val, val1;
            bool value = float.TryParse(AssesedValue, out val);
            bool value2 = float.TryParse(TotalTax, out val1);
            GrandTotal =  (val + val1).ToString("0.00");
        }



        /// <summary>
        /// Calculate total tax 
        /// </summary>
        private void GetTotalTax()
        {
            string decimalPlaces = "0.00";
            SwitchingCurrecny(AvailableCurrency);
            float value = float.Parse(AssesedValue);
            float nAcd, nCd, nSt, nIt;
            nAcd = ACD/ 100;
            nCd = CD/ 100;
            nSt = ST/ 100;
            nIt = IT/ 100;

            nAcd = value * nAcd;
            nCd = value*nCd;

            float sum = nCd + nAcd;

            nSt = sum * nSt;
            sum = sum + nSt;
            nIt = sum * nIt;
            sum = sum + nIt;

            TotalTax = (String)sum.ToString(decimalPlaces);

        }

        /// <summary>
        /// provides the condition for switching the currenct based on selection
        /// </summary>
        /// <param name="exhange">Available Currency type <see cref="AvailableCurrency"/></param>
        private void SwitchingCurrecny(string exhange)
        {
            switch (AvailableCurrency)
            {
                case "USD":
                    {
                        float value = ItemCost * UsdExchangeRate;
                        AssesedValueCalculation(value);
                        break;
                    }
                case "EURO":

                    {
                        float value = ItemCost * EuroExchangeRate;
                        AssesedValueCalculation(value);
                        break;
                    }
                case "GBP":

                    {
                        float value = ItemCost * GBPExchangeRate;
                        AssesedValueCalculation(value);
                        break;
                    }


                default:
                    break;
            }
            
            
        }

        /// <summary>
        /// AssesedValue Calculation
        /// </summary>
        /// <param name="value">converted item cost</param>
        private void AssesedValueCalculation(float value)
        {
            value = value + value * (CurrencyTolerancePercentage / 100);
            value = value + value * (InsurancePercentage / 100);
            AssesedValue = (String)value.ToString();
        }


        #endregion



    }
}
