using CriptoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CriptoApp.ViewModels
{
    public class UserSettingsViewModel : BaseViewModel
    {
        public ICommand UserInfoPopupIsVisibleCommand { get; set; }
        public ICommand UserPasswordPopupIsVisibleCommand { get; set; }
        public ICommand RegisterButtonIsEnableCommand { get; set; }
        public UserModel User { get; set; }
        public UserSettingsViewModel()
        {
            User = App.LoginModel;
            UserInfoPopupIsVisibleCommand = new Command(new Action(() => { if (UserInfoPopupIsVisible) UserInfoPopupIsVisible = false; else UserInfoPopupIsVisible = true; }));
            UserPasswordPopupIsVisibleCommand = new Command(new Action(() => { if (UserPasswordPopupIsVisible) UserPasswordPopupIsVisible = false; else UserPasswordPopupIsVisible = true; }));
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


        bool _RegisterButtonIsEnable = false;
        public bool RegisterButtonIsEnable
        {
            get { return _RegisterButtonIsEnable; }
            set { _RegisterButtonIsEnable = value; OnPropertyChanged("RegisterButtonIsEnable"); }
        }
    }
}
