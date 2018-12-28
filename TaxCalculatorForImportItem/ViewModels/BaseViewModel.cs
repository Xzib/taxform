using System.ComponentModel;
using System.Windows.Controls;

namespace TaxCalculatorForImportItem
{
    class BaseViewModel : INotifyPropertyChanged
    {
        private string mAssesedValue;
        private string mTax;
        private string gTotal;

        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {};

        public BaseViewModel()
        {
            mAssesedValue = "";
        }


        public string AssesedValue {
            get {
                return mAssesedValue;
                ;
            }
            set {
                if (mAssesedValue == value)
                    return;
                mAssesedValue = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(AssesedValue)));
            }
        }

        public string TotalTax
        {
            get
            {
                return mTax;
            }
            set
            {
                if (mTax == value)
                    return;
                mTax = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(TotalTax)));
            }

        }

        public string GrandTotal
        {
            get
            {
                return gTotal;
            }

            set
            {
                if (gTotal == value)
                    return;
                gTotal = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(GrandTotal)));
            }
        }
    }
}
