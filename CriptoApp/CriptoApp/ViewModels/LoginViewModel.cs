using CriptoApp.Helper;
using CriptoApp.Models;
using CriptoApp.Services;
using CriptoApp.Views;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CriptoApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public INavigation Navigation { get; set; }
        public ICommand GotoMainPageCommand { get; set; }
        public ICommand GotoRegisterPageCommand { get; set; }
        public ICommand LoginCheckCommand { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            this.GotoMainPageCommand = new Command(async () => await GotoMainPage());
            this.GotoRegisterPageCommand = new Command(async () => await GotoRegisterPage());


            this.LoginCheckCommand = new Command(async () => await LoginCheck());

        }

        LoginServiceDataStore loginServiceDataStore = new LoginServiceDataStore();
        private async Task LoginCheck()
        {
            await GotoMainPage();
            //if(string.IsNullOrEmpty(Email)||string.IsNullOrEmpty(Password))
            //{
            //    Device.BeginInvokeOnMainThread(() => AlertHelper.MessageAlert("Kullanıcı Adı ve Şifre Bölümlerini Boş Bırakmayın"));
            //    return;
            //}
            //MobileResult mobileResult = new MobileResult();
            //try
            //{
            //    IsBusy = true;
            //    mobileResult = await loginServiceDataStore.LoginAsync(Email, Password);
            //}
            //catch (Exception)
            //{

            //    Device.BeginInvokeOnMainThread(() => AlertHelper.ExceptionAlert());
            //}
            //finally
            //{
            //    IsBusy = false;
            //    if (mobileResult != null)
            //    {
            //        Device.BeginInvokeOnMainThread(() => AlertHelper.MessageAlert(mobileResult.Message));
            //        if (mobileResult != null && mobileResult.Result)
            //            await GotoMainPage();
            //    }
            //}
        }

        public async Task GotoMainPage()
        {
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                await Navigation.PushModalAsync(new MainPage());
            }
            catch (System.Exception)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task GotoRegisterPage()
        {
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                await Navigation.PushModalAsync(new UserRegisterPage());
            }
            catch (System.Exception)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }




    }
}
