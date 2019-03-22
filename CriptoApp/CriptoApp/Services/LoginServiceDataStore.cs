using CriptoApp.Helper;
using CriptoApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CriptoApp.Services
{
    public class LoginServiceDataStore : ServiceManager, IDataStore<UserModel>
    {
        public async Task<MobileResult> LoginAsync(string Email, string Password)
        {
            MobileResult mobileResult = new MobileResult();
            try
            {
                var Client = await GetClient();
                var response = await Client.GetStringAsync(APIUrl + "api/User/Login?Email=" + Email + "&Password=" + Password);
                mobileResult = JsonConvert.DeserializeObject<MobileResult>(response);
                return mobileResult;
            }
            catch (Exception)
            {
                AlertHelper.MessageAlert(mobileResult.Message);
                return mobileResult;
            }
        }

        public Task<MobileResult> AddItemAsync(UserModel item)
        {
            throw new NotImplementedException();
        }

        public Task<MobileResult> DeleteItemAsync(UserModel item)
        {
            throw new NotImplementedException();
        }

        public Task<MobileResult> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<MobileResult> GetItemNoParamAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<MobileResult> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<MobileResult> UpdateItemAsync(UserModel item)
        {
            throw new NotImplementedException();
        }
    }
}
