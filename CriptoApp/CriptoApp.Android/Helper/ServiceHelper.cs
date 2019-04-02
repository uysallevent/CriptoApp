using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CriptoApp.Droid.Helper;
using CriptoApp.Droid.Service;
using CriptoApp.Helper;

[assembly: Xamarin.Forms.Dependency(typeof(ServiceHelper))]
namespace CriptoApp.Droid.Helper
{
    public class ServiceHelper : IServiceHelper
    {
        public void StartIntentService()
        {
            Intent intent = new Intent(Application.Context, typeof(PortfoyNotifierService));
            Application.Context.StartService(intent);
        }

        public void StopIntentService()
        {
           
        }
    }
}