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
        Intent intent = new Intent(Application.Context, typeof(PortfoyNotifierService));

        public void StartIntentService()
        {
            Application.Context.StartService(intent);
        }

        public void StopIntentService()
        {
            Application.Context.StopService(intent);

        }
    }
}