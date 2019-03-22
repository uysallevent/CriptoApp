using CriptoApp.Helper;
using CriptoApp.Models;
using CriptoApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CriptoApp.ViewModels
{
    public class PortfoyViewModel : BaseViewModel
    {
        public ObservableCollection<CurrencyServiceModel> ListPortfoy { get; set; }
        SignalRClient client = new SignalRClient();
        CurrencyServiceModel _selectedModel;
        public CurrencyServiceModel selectedModel
        {
            get
            {
                return _selectedModel;
            }
            set
            {
                _selectedModel = value;
                OnPropertyChanged("selectedModel");
            }
        }

        public PortfoyViewModel()
        {
            Title = "Portföyüm";
            ListPortfoy = new ObservableCollection<CurrencyServiceModel>();
            client.Connect("android");
            client.ConnectionError += Client_ConnectionError;
            client.OnMessageReceived += Client_OnMessageReceived;
        }

        private void Client_OnMessageReceived(string ListCripto)
        {
            if (!ListCripto.Contains("Connected") && !ListCripto.Contains("Disconnected") && !ListCripto.Contains("Reconnected"))
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    try
                    {
                        if (IsBusy)
                            return;
                        IsBusy = true;
                        ListPortfoy.Clear();
                        string[] PortfoyArray = Settings.PortfoyList.Split('-');
                        var JsonListe = JsonConvert.DeserializeObject<ObservableCollection<CurrencyServiceModel>>(ListCripto);

                        foreach (var item in PortfoyArray)
                        {
                            var Bulunan = JsonListe.FirstOrDefault(x=>x.FullName==item);
                            if (Bulunan != null)
                                ListPortfoy.Add(Bulunan);
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    finally
                    {
                        IsBusy = false;
                    }

                });
            }
        }

        private void Client_ConnectionError()
        {
            

        }

    }
}
