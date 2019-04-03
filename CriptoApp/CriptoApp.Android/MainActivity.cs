using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xfx;
using System.IO;
using CriptoApp.SQLite;
using Android.Content;
using CriptoApp.Droid.Service;

namespace CriptoApp.Droid
{
    [Activity(Label = "CriptoApp", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            var dbPath = Path.Combine(System.Environment.GetFolderPath
                (System.Environment.SpecialFolder.Personal),"portfoyDB.db");
            var userPortfoyRepository = new UserPortfoyRepository(dbPath);

            XfxControls.Init();
            Xamarin.Forms.DataGrid.DataGridComponent.Init();
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App(userPortfoyRepository));
        }

    }
}