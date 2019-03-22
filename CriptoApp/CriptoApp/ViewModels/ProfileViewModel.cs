using CriptoApp.Helper;
using CriptoApp.Models;
using CriptoApp.Services;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CriptoApp.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        SignalRClient client = new SignalRClient();
        public ObservableCollection<CurrencyServiceModel> ListCriptoMoney { get; set; }
        public UserPortfoyModel userPortfoyModel { get; set; }
        public ICommand OpenMenuItemCommand { get; set; }
        public ICommand AddPortfoyCommand { get; set; }
        CurrencyServiceModel _model;

        public ProfileViewModel(CurrencyServiceModel model)
        {
            Title = model.FullName + " - " + model.FromSymbol;
            _model = model;
            ListCriptoMoney = new ObservableCollection<CurrencyServiceModel>();
            userPortfoyModel = new UserPortfoyModel();
            OpenMenuItemCommand = new Command(OpenMenuItem);
            AddPortfoyCommand = new Command(async () => await AddPortfoy());
            client.Connect("android");
            client.ConnectionError += Client_ConnectionError;
            client.OnMessageReceived += Client_OnMessageReceived;
        }

        private async Task AddPortfoy()
        {
            MobileResult mobileResult = new MobileResult();
            try
            {
                if(userPortfoyModel.PurchasePrice==0)
                {
                    AlertHelper.MessageAlert("Lütfen Alım Tutarı Girin");
                    return;
                }
                else if(userPortfoyModel.Quantity==0)
                {
                    AlertHelper.MessageAlert("Lütfen Alım Miktarı Girin");
                    return;
                }
                IsBusy = true;
                userPortfoyModel.Price = _model.Price;
                userPortfoyModel.CriptoName = _model.FullName;
                userPortfoyModel.CriptoSymbol = _model.FromSymbol;
                userPortfoyModel.UserId = App.LoginModel.Id;
                userPortfoyModel.IsDeleted = 0;

                mobileResult = await PortfoyServiceDataStore.AddItemAsync(userPortfoyModel);
                if(mobileResult.Result)
                {
                    var ListPortfoy = await PortfoyServiceDataStore.GetListAsync(App.LoginModel.Id);
                    App.ListUserPortfoy = JsonConvert.DeserializeObject<ObservableCollection<UserPortfoyModel>>(ListPortfoy.Content.ToString());
                    if (Settings.PortfoyList.Contains(_model.FullName+"-"+_model.FromSymbol))
                        return;
                    if (string.IsNullOrEmpty(Settings.PortfoyList))
                        Settings.PortfoyList = _model.FullName + "-" + _model.FromSymbol;
                    else
                        Settings.PortfoyList = Settings.PortfoyList + "," + _model.FullName + "-" + _model.FromSymbol;

                }
                Device.BeginInvokeOnMainThread(() => AlertHelper.MessageAlert(mobileResult.Message));
            }
            catch (Exception)
            {
                Device.BeginInvokeOnMainThread(() => AlertHelper.MessageAlert(mobileResult.Message));
            }
            finally
            {
                IsBusy = false;
            }

        }

        private void OpenMenuItem(object obj)
        {
            if (PopupIsVisible)
                PopupIsVisible = false;
            else
                PopupIsVisible = true;

        }

        private void Client_OnMessageReceived(string ListCripto)
        {
            if (!ListCripto.Contains("Connected") && !ListCripto.Contains("Disconnected") && !ListCripto.Contains("Reconnected"))
            {
                try
                {
                    var JsonListe = JsonConvert.DeserializeObject<ObservableCollection<CurrencyServiceModel>>(ListCripto);
                    if (ListCriptoMoney.Count == 0)
                    {
                        foreach (var item in JsonListe.Where(x => x.FromSymbol == _model.FromSymbol))
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
                catch (Exception ex)
                {

                }
            }

        }

        private void Client_ConnectionError()
        {
        }
    }
}
