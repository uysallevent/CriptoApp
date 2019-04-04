using CriptoApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace CriptoApp.Helper
{
    public class SQLiteManager
    {
        SQLiteConnection _sQLiteConnection;

        public SQLiteManager()
        {
            _sQLiteConnection = DependencyService.Get<ISQLiteConnection>().GetConnection();
            _sQLiteConnection.CreateTable<UserPortfoyModel>();
        }

        public int Insert(UserPortfoyModel model)
        {
            return _sQLiteConnection.Insert(model);
        }

        public int Update(UserPortfoyModel model)
        {
            return _sQLiteConnection.Update(model);
        }

        public int Delete(int id)
        {
            return _sQLiteConnection.Delete<UserPortfoyModel>(id);
        }

        public int DeleteWithSQLServerId(int id)
        {
            var Delete = _sQLiteConnection.Table<UserPortfoyModel>().FirstOrDefault(x => x.SQLServerID == id);
            return _sQLiteConnection.Delete<UserPortfoyModel>(Delete.Id);
        }

        public List<UserPortfoyModel>GetAll()
        {
            return _sQLiteConnection.Table<UserPortfoyModel>().ToList();
        }

        public UserPortfoyModel GetByID(int id)
        {
            return _sQLiteConnection.Table<UserPortfoyModel>().FirstOrDefault(x=>x.Id==id);
        }

        public IList<UserPortfoyModel> QueryPortfoyAsync(Func<UserPortfoyModel, bool> predicate)
        {
            return _sQLiteConnection.Table<UserPortfoyModel>().Where(predicate).ToList();
        }

        public void Dispose()
        {
            _sQLiteConnection.Dispose();
        }
    }
}
