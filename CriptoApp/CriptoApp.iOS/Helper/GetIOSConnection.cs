using CriptoApp.Helper;
using CriptoApp.iOS.Helper;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;

[assembly:Xamarin.Forms.Dependency(typeof(CriptoApp.iOS.Helper.GetIOSConnection))]
namespace CriptoApp.iOS.Helper
{
    public class GetIOSConnection : ISQLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentPath,App.DbName);
            var platform =new SQLitePlatformIOS();
            var connection = new SQLiteConnection(platform,path);
            return connection;
        }
    }
}