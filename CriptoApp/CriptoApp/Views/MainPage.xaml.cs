using System;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CriptoApp.Helper;

namespace CriptoApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : Xamarin.Forms.TabbedPage
    {
        public MainPage()
        {
            IsBusy = true;
            try
            {
                InitializeComponent();
                On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(() => AlertHelper.MessageAlert(ex.Message));
            }
            finally
            {
                IsBusy = false;
            }

        }
    }
}