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

namespace CriptoApp.Droid.Service
{
    [Service]
    public class PortfoyNotifierService : IntentService
    {
        IntentFilter intentfilter;

        public override void OnCreate()
        {
            base.OnCreate();
            intentfilter = new IntentFilter("MY_ACTION");
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Toast.MakeText(this, "Intent Service is start", ToastLength.Long).Show();
            return StartCommandResult.NotSticky;
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
            Toast.MakeText(this, "Intent Service Destroyed", ToastLength.Long).Show();
        }
        protected override void OnHandleIntent(Intent intent)
        {
            string message = intent.GetStringExtra("Test_Message");
            Intent broadcastIntent = new Intent("MY_ACTION");
            broadcastIntent.PutExtra("Test_Message", message + "Readers....!!!!!");
            SendBroadcast(broadcastIntent);
        }
    }
}