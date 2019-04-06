using CriptoApp.Helper;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(CriptoApp.iOS.Helper.GetIOSConnection))]
namespace CriptoApp.iOS.Helper
{
    public class GetIOSConnection : ISQLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentPath,App.DbName);
            var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}