using Review.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Review.ViewModel
{
    public class CurrencyDetailsVM : INotifyPropertyChanged
    {
        private Currency _selectedCurrency;
        public Currency SelectedCurrency
        {
            get { return _selectedCurrency; }
            set
            {
                _selectedCurrency = value;
                OnPropertyChanged("SelectedCurrency");
            }
        }

        public CurrencyDetailsVM(Currency currency)
        {
            SelectedCurrency = currency;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
