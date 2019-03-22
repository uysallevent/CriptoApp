using System;
using System.Collections.Generic;
using System.Text;

namespace CriptoApp.Helper
{
    public class AlertHelper
    {
        public static void ExceptionAlert()
        {
            App.Current.MainPage.DisplayAlert("Uyarı", "Bir Hata Oluştu", "Tamam");
        }

        public static void MessageAlert(string Message)
        {
            App.Current.MainPage.DisplayAlert("Uyarı", Message, "Tamam");
        }
    }
}