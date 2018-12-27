using System.ComponentModel;
using System.Windows.Controls;

namespace TaxCalculatorForImportItem
{
    class BaseViewModel : INotifyPropertyChanged
    {
        private string mAssesedValue;
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
    }
}
