using CriptoApp.Helper;
using CriptoApp.Models;
using CriptoApp.Services;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CriptoApp.ViewModels
{
    public class UserSettingsViewModel : BaseViewModel
    {
        UserServiceDataStore userServiceDataStore = new UserServiceDataStore();
        public ICommand UserInfoPopupIsVisibleCommand { get; set; }
        public ICommand UserPasswordPopupIsVisibleCommand { get; set; }
        public ICommand RegisterButtonIsEnableCommand { get; set; }
        public ICommand UserInfoUpdateCommand { get; set; }
        public ICommand UserPasswordUpdateCommand { get; set; }
        public ICommand BackButtonCommand { get; set; }
        public UserModel User { get; set; }
        private string _OldPassword;
        public string OldPassword
        {
            get { return _OldPassword; }
            set { _OldPassword =value;OnPropertyChanged("OldPassword"); }
        }
        private string _NewPassword;
        public string NewPassword
        {
            get { return _NewPassword; }
            set { _NewPassword = value;OnPropertyChanged("NewPassword"); }
        }

        public UserSettingsViewModel()
        {
            User = App.LoginModel;
            UserInfoPopupIsVisibleCommand = new Command(new Action(() => { if (UserInfoPopupIsVisible) UserInfoPopupIsVisible = false; else UserInfoPopupIsVisible = true; }));
            UserPasswordPopupIsVisibleCommand = new Command(new Action(() => { if (UserPasswordPopupIsVisible) UserPasswordPopupIsVisible = false; else UserPasswordPopupIsVisible = true; }));
            UserInfoUpdateCommand = new Command(async () => await UserInfoUpdate());
            UserPasswordUpdateCommand = new Command(async () => await UserPasswordUpdate());
            BackButtonCommand = new Command(async()=> { await Application.Current.MainPage.Navigation.PopModalAsync(); });
            RegisterButtonIsEnable = true;
        }

        private async Task UserPasswordUpdate()
        {
            MobileResult result = new MobileResult();
            try
            {
                if(string.IsNullOrEmpty(NewPassword)||string.IsNullOrEmpty(OldPassword))
                {
                    Device.BeginInvokeOnMainThread(() => AlertHelper.MessageAlert("Lütfen Mevcut Şifrenizi ve Yeni Şifrenizi Girin !!"));
                    return;
                }
                if (MD5Transactions.MD5eDonustur(OldPassword) == App.LoginModel.Password)
                {
                    IsBusy = true;
                    App.LoginModel.Password = MD5Transactions.MD5eDonustur(NewPassword);
                    result = await userServiceDataStore.UpdateItemAsync(App.LoginModel);
                    Device.BeginInvokeOnMainThread(() => AlertHelper.MessageAlert(result.Message));
                }
                else
                    Device.BeginInvokeOnMainThread(() => AlertHelper.MessageAlert("Lütfen Şifrenizi Kontrol Ediniz"));

            }
            catch (Exception)
            {
                Device.BeginInvokeOnMainThread(() => AlertHelper.ExceptionAlert());

            }
            finally
            {
                OldPassword = "";
                NewPassword = "";
                UserInfoPopupIsVisible = false;
                UserPasswordPopupIsVisible = false;
                IsBusy = false;
            }
        }

        private async Task UserInfoUpdate()
        {
            MobileResult result = new MobileResult();
            try
            {
                IsBusy = true;
                result = await userServiceDataStore.UpdateItemAsync(User);
                AlertHelper.MessageAlert(result.Message);

            }
            catch (Exception)
            {
                AlertHelper.ExceptionAlert();
            }
            finally
            {
                App.LoginModel = JsonConvert.DeserializeObject<UserModel>(result.Content.ToString());
                UserInfoPopupIsVisible = false;
                UserPasswordPopupIsVisible = false;
                IsBusy = false;
            }

        }

        bool _UserInfoPopupIsVisible = false;
        public bool UserInfoPopupIsVisible
        {
            get { return _UserInfoPopupIsVisible; }
            set { _UserInfoPopupIsVisible = value; OnPropertyChanged("UserInfoPopupIsVisible"); }
        }

        bool _UserPasswordPopupIsVisible = false;
        public bool UserPasswordPopupIsVisible
        {
            get { return _UserPasswordPopupIsVisible; }
            set { _UserPasswordPopupIsVisible = value; OnPropertyChanged("UserPasswordPopupIsVisible"); }
        }

        bool _RegisterButtonIsEnable;
        public bool RegisterButtonIsEnable
        {
            get { return _RegisterButtonIsEnable; }
            set { _RegisterButtonIsEnable = value; OnPropertyChanged("RegisterButtonIsEnable"); }
        }
    }
}
