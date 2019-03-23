using CriptoApp.Helper;
using CriptoApp.Models;
using CriptoApp.Services;
using CriptoApp.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CriptoApp.ViewModels
{
    public class CriptoListViewModel : BaseViewModel
    {
        SignalRClient client = new SignalRClient();
        IList<CurrencyServiceModel> model = new ObservableCollection<CurrencyServiceModel>();

        public ObservableCollection<CurrencyServiceModel> ListCriptoMoney { get; set; }
        public ObservableCollection<CurrencyModel> ListCurrency { get; set; }
        private CurrencyModel _currencyModel;

        public CurrencyModel currencyModel
        {
            get { return _currencyModel; }
            set
            {
                if (value.CurrencyShortening != null)
                {
                    _currencyModel = value;
                    //client.SendMessage("android", _currencyModel.CurrencyShortening);
                }
            }
        }

        CurrencyServiceModel _selectedModel;
        public CurrencyServiceModel selectedModel
        {
            get
            {
                return _selectedModel;
            }

            set
            {
                if (value != null)
                {
                    _selectedModel = value;
                    selectedItem = _selectedModel.FullName;
                    OnItemSelected(_selectedModel);
                    selectedModel = null;
                    OnPropertyChanged("selectedModel");
                }
            }
        }
        public INavigation Navigation { get; set; }
        public ICommand SetVisibleCommand { get; set; }

        public CriptoListViewModel(INavigation navigation)
        {
            Title = "Kripto Paralar";
            Navigation = navigation;
            ListCurrency = new ObservableCollection<CurrencyModel> {
                new CurrencyModel(){Id=1,CurrencyName="LİRA",CurrencyShortening="CurrencyTRY" },
                new CurrencyModel(){Id=2,CurrencyName="DOLAR",CurrencyShortening="CurrencyUSD" },
                new CurrencyModel(){Id=3,CurrencyName="EURO",CurrencyShortening="CurrencyEUR" }
            };
            currencyModel = new CurrencyModel();
            SetVisibleCommand = new Command(SetVisible);
            ListCriptoMoney = new ObservableCollection<CurrencyServiceModel>();
            if (ListCriptoMoney == null || ListCriptoMoney.Count == 0)
                IsBusy = true;
            App.client = new SignalRClient();
            App.client.Connect("android");
            App.client.ConnectionError += Client_ConnectionError;
            App.client.OnMessageReceived += Client_OnMessageReceived;
        }

        private void SetVisible(object obj)
        {
            if (PopupIsVisible)
                PopupIsVisible = false;
            else
                PopupIsVisible = true;
        }

        private async void OnItemSelected(CurrencyServiceModel Selected)
        {
            if (Selected == null)
                return;
            try
            {
                await Navigation.PushAsync(new ProfilePage(Selected));
            }
            catch (System.Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", "Bir hata oluştu. Lütfen tekrar deneyiniz", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }

            //PopupIsVisible = true;
            //if (Settings.PortfoyList.Contains(Selected.FullName))
            //    return;
            //if (string.IsNullOrEmpty(Settings.PortfoyList))
            //    Settings.PortfoyList = Selected.FullName;
            //else
            //    Settings.PortfoyList = Settings.PortfoyList + "-" + Selected.FullName;
        }

        private void Client_OnMessageReceived(string ListCripto)
        {
            try
            {
                if (ListCriptoMoney == null || ListCriptoMoney.Count == 0)
                    IsBusy = true;
                else
                    IsBusy = false;
                if (!ListCripto.Contains("Connected") && !ListCripto.Contains("Disconnected") && !ListCripto.Contains("Reconnected"))
                {

                    var JsonListe = JsonConvert.DeserializeObject<ObservableCollection<CurrencyServiceModel>>(ListCripto);
                    if (ListCriptoMoney.Count == 0)
                    {
                        ListCriptoMoney.Clear();
                        foreach (var item in JsonListe)
                        {
                            ListCriptoMoney.Add(item);
                        }
                    }
                    else
                    {
                        foreach (var item in JsonListe)
                        {
                            var model = ListCriptoMoney.FirstOrDefault(x => x.FromSymbol == item.FromSymbol);
                            if (model.Price > item.Price)
                                model.Change = 0;
                            else if (model.Price < item.Price)
                                model.Change = 1;
                            else
                                model.Change = 2;

                            model.Price = item.Price;
                            model.Change24 = item.Change24;

                        }
                    }

                }
                else
                    DependencyService.Get<IToastHelper>().ToastMessage(ListCripto);
            }
            catch (Exception ex)
            {

            }
        }

        private void Client_ConnectionError()
        {

        }

        async Task GetCriptoMoneyList()
        {
            if (IsBusy)
                return;
            IsBusy = true;
            try
            {
                ListCriptoMoney.Clear();
                var items = await CriptoServiceDataStore.GetItemsAsync(false);

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }

        }

        static List<CurrencyServiceModel> StatikListe = new List<CurrencyServiceModel>();
    }
}
