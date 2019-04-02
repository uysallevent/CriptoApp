using CriptoApp.Models;
using CriptoApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CriptoApp.SQLite
{
    public class UserPortfoyRepository : IPortfoyRepository
    {
        private readonly DatabaseContext _databaseContext;
        public UserPortfoyRepository(string dbPath)
        {
            _databaseContext = new DatabaseContext(dbPath);
        }

        public async Task<bool> AddPortfoyAsync(UserPortfoyModel userPortfoyModel)
        {
            try
            {
                var Portfoy = await _databaseContext.UserPortfoy.AddAsync(userPortfoyModel);
                await _databaseContext.SaveChangesAsync();
                var IsAdded = Portfoy.State == EntityState.Added;
                return IsAdded;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<UserPortfoyModel>> GetPortfoyAsync()
        {
            try
            {
                var PortfoyList = await _databaseContext.UserPortfoy.ToListAsync();
                return PortfoyList;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<UserPortfoyModel> GetPortfoyByIdAsync(int id)
        {
            try
            {
                var Portfoy = await _databaseContext.UserPortfoy.FindAsync(id);
                return Portfoy;
            }
            catch (Exception)
            {
                return null;
            }

        }

        public async Task<IEnumerable<UserPortfoyModel>> QueryPortfoyAsync(Func<UserPortfoyModel, bool> predicate)
        {
            try
            {
                var Portfoy =  _databaseContext.UserPortfoy.Where(predicate);
                return Portfoy.ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> RemovePortfoyAsync(int id)
        {
            try
            {
                var Portfoy = await _databaseContext.UserPortfoy.FindAsync(id);
                var Delete = _databaseContext.Remove(Portfoy);
                await _databaseContext.SaveChangesAsync();
                var Deleted = Delete.State == EntityState.Deleted;
                return Deleted;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public async Task<bool> UpdateProductAsync(UserPortfoyModel userPortfoyModel)
        {
            try
            {
                var Portfoy =  _databaseContext.Update(userPortfoyModel);
                await _databaseContext.SaveChangesAsync();
                var Updated = Portfoy.State == EntityState.Modified;
                return Updated;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
