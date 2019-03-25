using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace CriptoApp.Models
{
    public class CurrencyServiceModel : INotifyPropertyChanged
    {

        public string PriceToSymbol { get { return ToSymbol + Price.ToString(); } }

        public string CustomOPENDAY { get { return ToSymbol + OPENDAY.ToString(); } }

        public string CustomLOWDAY { get { return ToSymbol + LOWDAY.ToString(); } }

        public string CustomHIGHDAY { get { return ToSymbol + HIGHDAY.ToString(); } }

        public string FromSymbol { get; set; }

        public string ToSymbol { get; set; }

        public string Name { get; set; }

        public string FullName { get; set; }

        public string ImageUrl { get; set; }

        private decimal _Price;

        public decimal Price
        {
            get { return _Price; }
            set
            {
                _Price = System.Math.Round(value, 2);
                OnPropertyChange("Price");
            }
        }

        public int Renk
        {
            get
            {
                return new Random().Next(0, 3);
            }
        }

        public decimal High24 { get; set; }

        public decimal Low24 { get; set; }

        //public double Change24 { get; set; }

        private decimal _Change24;

        public decimal Change24
        {
            get { return _Change24; }
            set
            {
                _Change24 = System.Math.Round(value, 3);
                OnPropertyChange("Change24");
            }
        }

        private int _Change;

        public int Change
        {
            get { return _Change; }
            set
            {
                _Change = value;
                OnPropertyChange("Change");
            }
        }

        private decimal _OPENDAY;
        public decimal OPENDAY
        {
            get { return _OPENDAY; }
            set
            {
                _OPENDAY = value;
                OnPropertyChange("OPENDAY");
            }
        }

        private decimal _HIGHDAY;
        public decimal HIGHDAY
        {
            get { return _HIGHDAY; }
            set
            {
                _HIGHDAY = value;
                OnPropertyChange("HIGHDAY");
            }
        }

        private decimal _LOWDAY;
        public decimal LOWDAY
        {
            get { return _LOWDAY; }
            set
            {
                _LOWDAY = value;
                OnPropertyChange("LOWDAY");
            }
        }

        private string _LASTUPDATE;

        public string LASTUPDATE
        {
            get { return _LASTUPDATE; }
            set
            {
                _LASTUPDATE = value;
                OnPropertyChange("LASTUPDATE");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChange([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
