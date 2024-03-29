﻿using CriptoApp.Helper;
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
        public SignalRClient client;

        private ObservableCollection<string> _SortList;
        public ObservableCollection<string> SortList { get { return _SortList; } set { _SortList = value; OnPropertyChanged("SortList"); } }
        public ObservableCollection<CurrencyServiceModel> ListCriptoMoney { get; set; }
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

        public bool _SortingVisibility = false;
        public bool SortingVisibility { get { return _SortingVisibility; } set { _SortingVisibility = value; OnPropertyChanged("SortingVisibility"); } }

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
                    _selectedModel = null;
                    OnPropertyChanged("selectedModel");
                }
            }
        }

        private string _selectedSortingMode;

        public string selectedSortingMode {
            get { return _selectedSortingMode; }
            set { _selectedSortingMode = value; OnPropertyChanged("selectedSortingMode"); _selectedSortingMode = null;   } }
        public INavigation Navigation { get; set; }
        public ICommand GotoUserPageCommand { get; set; }
        public ICommand SortingVisibilityCommand { get; set; }
        public CriptoListViewModel(INavigation navigation)
        {
            Title = "Kripto Paralar";
            Navigation = navigation;
            currencyModel = new CurrencyModel();
            GotoUserPageCommand = new Command(async () => await GotoUserPage());
            ListCriptoMoney = new ObservableCollection<CurrencyServiceModel>();
            SortList = new ObservableCollection<string>();
            SortList.Add("İSİM");
            SortList.Add("FİYAT");
            SortList.Add("DEĞİŞİM 24 SA.");
            SortingVisibilityCommand = new Command(() =>
            {
                if (SortingVisibility) SortingVisibility = false;
                else
                    SortingVisibility = true;
            });
            if (ListCriptoMoney == null || ListCriptoMoney.Count == 0)
                IsBusy = true;
            if (client == null)
                client = new SignalRClient();
            client.Connect(App.LoginModel.Id.ToString() + "-" + "CryptoListe");
            client.ConnectionError += Client_ConnectionError;
            client.OnMessageReceived += Client_OnMessageReceived;
        }
        private async Task GotoUserPage()
        {
            try
            {
                IsBusy = true;
                await Navigation.PushModalAsync(new UserSettingsPage());
            }
            catch (System.Exception)
            {

            }
            finally
            {
                IsBusy = false;
            }

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
            Device.BeginInvokeOnMainThread(() =>
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
                                if (model == null)
                                    continue;
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
                }
                catch (Exception ex)
                {
                    AlertHelper.MessageAlert(ex.Message);
                }
            });
        }
        private void Client_ConnectionError()
        {
            try
            {
                if (client == null)
                    client = new SignalRClient();
                client.Connect(App.LoginModel.Id.ToString() + "-" + "CryptoListe");
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(() => AlertHelper.MessageAlert(ex.Message));
            }

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
    }
}
