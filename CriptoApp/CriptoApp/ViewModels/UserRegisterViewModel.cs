using CriptoApp.Helper;
using CriptoApp.Models;
using CriptoApp.Services;
using CriptoApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CriptoApp.ViewModels
{
    public class UserRegisterViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }
        public ICommand OnBackActionCommand { get; set; }
        public ICommand UserRegisterCommand { get; set; }
        public ICommand RefreshCommand
        {
            get
            {
                return new Command( () =>
                {
                    UserModel = new UserModel();
                });
            }
        }

        private UserModel _UserModel;

        public UserModel UserModel
        {
            get { return _UserModel; }
            set { _UserModel = value;
                OnPropertyChanged("UserModel");
            }
        }

        public UserRegisterViewModel(INavigation navigation)
        {
            this.Navigation = navigation;
            OnBackActionCommand = new Command(async () => await OnBackAction());
            this.UserRegisterCommand = new Command(async () => await UserRegister());
            UserModel = new UserModel();
        }

        private async Task OnBackAction()
        {
            try
            {
                await Navigation.PopModalAsync();
            }
            catch (System.Exception)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }

        UserServiceDataStore userServiceDataStore = new UserServiceDataStore();
        public async Task UserRegister()
        {
            MobileResult result = new MobileResult();
            try
            {
                IsBusy = true;
                UserModel.Crated = DateTime.Now;
                UserModel.Update = DateTime.Now;
                UserModel.Delete = DateTime.Now;
                UserModel.IsDeleted = 0;
                result = await userServiceDataStore.AddItemAsync(UserModel);
            }
            catch (Exception)
            {
                AlertHelper.ExceptionAlert();
            }
            finally
            {
                IsBusy = false;
                if(result.Result)
                    UserModel = new UserModel();
                AlertHelper.MessageAlert(result.Message);
            }


        }
    }
}
