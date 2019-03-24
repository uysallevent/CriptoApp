using CriptoApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System;

namespace CriptoApp.Services
{
    public class CriptoServiceDataStore : ServiceManager, IDataStore<CriptoCurrencyModel>
    {
        IList<CriptoCurrencyModel> ListCripto;

        public CriptoServiceDataStore()
        {

        }

        public async Task<MobileResult> AddItemAsync(CriptoCurrencyModel item)
        {
            throw new NotImplementedException();
        }

        public async Task<MobileResult> UpdateItemAsync(CriptoCurrencyModel item)
        {
            throw new NotImplementedException();

        }

        public async Task<MobileResult> DeleteItemAsync(CriptoCurrencyModel item)
        {
            throw new NotImplementedException();

        }

        public async Task<MobileResult> GetItemAsync(string id)
        {
            throw new NotImplementedException();

        }

        public async Task<MobileResult> GetItemsAsync(bool forceRefresh = false)
        {

            throw new NotImplementedException();
        }

        public async Task<MobileResult> GetItemNoParamAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<MobileResult> GetListAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<MobileResult> GetListAsync(CriptoCurrencyModel item)
        {
            throw new NotImplementedException();
        }
    }
}