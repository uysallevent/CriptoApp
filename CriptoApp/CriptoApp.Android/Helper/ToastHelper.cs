using Android.Widget;
using CriptoApp.Droid.Helper;
using CriptoApp.Helper;

[assembly: Xamarin.Forms.Dependency(typeof(ToastHelper))]
namespace CriptoApp.Droid.Helper
{
    public class ToastHelper : IToastHelper
    {
        public void ToastMessage(string Message)
        {
            Toast.MakeText(Android.App.Application.Context, Message, ToastLength.Short).Show();
        }
    }
}