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
        public SignalRClient client;
        public ObservableCollection<CurrencyServiceModel> ListPortfoy { get; set; }
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
            if (client == null)
                client = new SignalRClient();
            client.Connect(App.LoginModel.Id.ToString() + "-" + "CryptoListe");
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
                       var JsonListe = JsonConvert.DeserializeObject<ObservableCollection<CurrencyServiceModel>>(ListCripto);
                       if (ListPortfoy.Count == 0)
                       {
                           ListPortfoy.Clear();
                           foreach (var item in App.ListUserPortfoy)
                           {
                               var Eklenecek = JsonListe.FirstOrDefault(x => x.FullName == item.CriptoName);
                               if (Eklenecek == null)
                                   continue;
                               if (ListPortfoy.FirstOrDefault(x => x.FullName == item.CriptoName) != null)
                                   continue;
                               ListPortfoy.Add(Eklenecek);
                           }
                       }
                       else
                       {
                           foreach (var item in JsonListe)
                           {
                               var Guncellenecek = ListPortfoy.FirstOrDefault(x => x.FullName == item.FullName);
                               if (Guncellenecek == null)
                                   continue;
                               if (Guncellenecek.Price > item.Price)
                                   Guncellenecek.Change = 0;
                               else if (Guncellenecek.Price < item.Price)
                                   Guncellenecek.Change = 1;
                               else
                                   Guncellenecek.Change = 2;
                               Guncellenecek.Price = item.Price;
                               Guncellenecek.Change24 = item.Change24;
                           }
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
