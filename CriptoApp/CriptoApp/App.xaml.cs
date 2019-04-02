using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CriptoApp.Views;
using CriptoApp.Models;
using System.Collections;
using System.Collections.ObjectModel;
using CriptoApp.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace CriptoApp
{
    public partial class App : Application
    {

        public App(IPortfoyRepository portfoyRepository)
        {
            InitializeComponent();
            _portfoyRepository = portfoyRepository;
            MainPage = new LoginPage();
        }

        public static IPortfoyRepository _portfoyRepository;

        public static UserModel LoginModel { get; set; }

        public static ObservableCollection<CurrencyServiceModel> ListCriptoMoney { get; set; }

        public static ObservableCollection<UserPortfoyModel> ListUserPortfoy { get; set; }

        public static SignalRClient client;

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
