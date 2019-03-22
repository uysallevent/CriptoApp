using System;
using System.Collections.Generic;
using System.Text;

namespace CriptoApp.Models
{
    public class CriptoCurrencyModel
    {
        public string TYPE { get; set; }
        public string MARKET { get; set; }
        private string _FROMSYMBOL;
        public string FROMSYMBOL
        {
            get { return _FROMSYMBOL; }


            set
            {
                if (value == "BTC")
                    _FROMSYMBOL = "Bitcoin";
                else if (value == "ETH")
                    _FROMSYMBOL = "Etherium";
                else if (value == "XRP")
                    _FROMSYMBOL = "Ripple";
                else if (value == "LTC")
                    _FROMSYMBOL = "Litecoin";
                else if (value == "XLM")
                    _FROMSYMBOL = "Stellar";
                else if (value == "USDT")
                    _FROMSYMBOL = "Tether";
                else if (value == "TRX")
                    _FROMSYMBOL = "TRON";
                else
                    _FROMSYMBOL = value;

            }
        }
        //public string FROMSYMBOL { get; set; }
        public string TOSYMBOL { get; set; }
        public string FLAGS { get; set; }
        public double? PRICE { get; set; }
        public int LASTUPDATE { get; set; }
        public double? LASTVOLUME { get; set; }
        public double? LASTVOLUMETO { get; set; }
        public string LASTTRADEID { get; set; }
        public double? VOLUMEDAY { get; set; }
        public double? VOLUMEDAYTO { get; set; }
        public double? VOLUME24HOUR { get; set; }
        public double? VOLUME24HOURTO { get; set; }
        public double? OPENDAY { get; set; }
        public double? HIGHDAY { get; set; }
        public double? LOWDAY { get; set; }
        public double? OPEN24HOUR { get; set; }
        public double? HIGH24HOUR { get; set; }
        public double? LOW24HOUR { get; set; }
        public string LASTMARKET { get; set; }
        public double? VOLUMEHOUR { get; set; }
        public double? VOLUMEHOURTO { get; set; }
        public double? OPENHOUR { get; set; }
        public double? HIGHHOUR { get; set; }
        public double? LOWHOUR { get; set; }
        public string CHANGE24HOUR { get; set; }
        public double? CHANGEPCT24HOUR { get; set; }
        public double? CHANGEDAY { get; set; }
        public double? CHANGEPCTDAY { get; set; }
        //public double? SUPPLY { get; set; }
        public double? MKTCAP { get; set; }
        public double? TOTALVOLUME24H { get; set; }
        public double? TOTALVOLUME24HTO { get; set; }
        public string IMAGEURL { get; set; }
    }

}
