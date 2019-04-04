using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using CriptoApp.Helper;
using CriptoApp.Models;
using CriptoApp.Services;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace CriptoApp.Droid.Service
{
    [Service]
    public class PortfoyNotifierService : IntentService
    {
        IntentFilter intentfilter;
        SignalRClient client;
        SQLiteManager sQLiteManager;
        public override void OnCreate()
        {
            base.OnCreate();
            intentfilter = new IntentFilter("MY_ACTION");
            if (client == null)
                client = new SignalRClient();
            client.Connect(App.LoginModel.Id.ToString() + "-" + "CryptoListe");
            client.ConnectionError += Client_ConnectionError;
            client.OnMessageReceived += Client_OnMessageReceived;
            sQLiteManager = new SQLiteManager();
        }

        private void Client_OnMessageReceived(string ListCripto)
        {
            if (!ListCripto.Contains("Connected") && !ListCripto.Contains("Disconnected") && !ListCripto.Contains("Reconnected"))
            {
                var LocalPortfoyList = sQLiteManager.GetAll();
                var JsonListe = JsonConvert.DeserializeObject<List<CurrencyServiceModel>>(ListCripto);
                foreach (var item in LocalPortfoyList)
                {
                    if (JsonListe.Any(x => x.Price <= item.StopLoss))
                    {
                            sQLiteManager.Delete(item.Id);
                            NotificationCompat.Builder builder = new NotificationCompat.Builder(this, "")
                                .SetContentTitle("CriptoApp Stop Loss")
                                .SetContentText(item.CriptoName + " stop loss noktasında pasife alındı")
                                .SetSmallIcon(Resource.Drawable.icon_portfoy);
                            Notification notification = builder.Build();
                            NotificationManager notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;
                            const int notificationId = 0;
                            notificationManager.Notify(notificationId, notification);
                    }
                }
            }

        }

        private void Client_ConnectionError()
        {

        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            return StartCommandResult.NotSticky;
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();
        }
        protected override void OnHandleIntent(Intent intent)
        {

        }
    }
}