using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CriptoApp.Services
{
    public class ServiceManager
    {
        public string APIUrl = "https://cryptoserviceapi.azurewebsites.net/";
        //public string APIUrl = "http://192.168.0.21:45455/";
        public string CryptoAPIUrl = "https://min-api.cryptocompare.com/data/pricemultifull?fsyms=BTC,ETH,XRP,LTC,EOS,BCH,BNB,USDT,XLM,TRX&tsyms=USD&api_key="+ "f74cff2c8a07629dc52a81ee94b0f8342a0495434e84b69ac58bd7c1d804e3e5";

        protected static HttpClient Client;
        protected static object lockObj = new object();

        public async Task<HttpClient> GetClient()
        {
            lock (lockObj)
            {
                if (Client == null)
                    Client = new HttpClient();
            }
            Client.Timeout = TimeSpan.FromMinutes(1);
            Client.DefaultRequestHeaders.Add("accept", "Applciation/json");
            return Client;
        }
    }
}
