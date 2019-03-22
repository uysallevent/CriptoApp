using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace CriptoApp.Models
{
    public class CurrencyModel: INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _CurrencyName;
        public string CurrencyName
        {
            get { return _CurrencyName; }
            set { _CurrencyName = value;
                OnPropertyChange("CurrencyName");
            }
        }

        private string _CurrencyShortening;
        public string CurrencyShortening
        {
            get { return _CurrencyShortening; }
            set { _CurrencyShortening = value;
                OnPropertyChange("CurrencyShortening");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChange([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
