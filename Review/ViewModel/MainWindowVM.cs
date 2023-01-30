using Review.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Review.Utils;
using System.Net.Http;
using Newtonsoft.Json;

namespace Review.ViewModel
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        private List<Currency> _currencies;
        private Currency _selectedCurrency;
        private ICommand _searchCommand;

        public MainWindowVM()
        {            
            LoadData();
        }

        public List<Currency> Currencies
        {
            get => _currencies;
            set
            {
                _currencies = value;
                OnPropertyChanged(nameof(Currencies));
            }
        }

        public Currency SelectedCurrency
        {
            get => _selectedCurrency;
            set
            {
                _selectedCurrency = value;
                OnPropertyChanged(nameof(SelectedCurrency));
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                {
                    _searchCommand = new RelayCommand(param => Search(), param => CanSearch());
                }
                return _searchCommand;
            }
        }

        private void LoadData()
        {
            //load the top 10 currency data to the Currencies property from API
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://api.coincap.io/v2/assets").Result;
                if (response.IsSuccessStatusCode)
                {
                    var content = response.Content.ReadAsStringAsync().Result;                    
                }
            }
        }

        private void Search()
        {            
        }

        private bool CanSearch()
        {            
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
