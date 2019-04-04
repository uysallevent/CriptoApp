using CriptoApp.Droid.Helper;
using CriptoApp.Helper;
using SQLite;

[assembly: Xamarin.Forms.Dependency(typeof(GetDroidConnection))]
namespace CriptoApp.Droid.Helper
{
    public class GetDroidConnection : ISQLiteConnection
    {
        public SQLiteConnection GetConnection()
        {
         

            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentPath,App.DbName);
             var connection = new SQLiteConnection(path);
            return connection;
        }
    }
}