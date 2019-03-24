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
    public class UserServiceDataStore : ServiceManager, IDataStore<UserModel>
    {
        public async Task<MobileResult> AddItemAsync(UserModel item)
        {
            MobileResult mobileResult = new MobileResult();
            try
            {
                var Client = await GetClient();
                var response = await Client.PostAsync(APIUrl + "api/User/AddUser", new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));
                var ResponseContent = await response.Content.ReadAsStringAsync();
                mobileResult = JsonConvert.DeserializeObject<MobileResult>(ResponseContent);
                return mobileResult;
            }
            catch (Exception)
            {
                AlertHelper.MessageAlert(mobileResult.Message);
                return mobileResult;
            }

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

        public Task<MobileResult> GetListAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<MobileResult> GetListAsync(UserModel item)
        {
            throw new NotImplementedException();
        }

        public Task<MobileResult> UpdateItemAsync(UserModel item)
        {
            throw new NotImplementedException();
        }
    }
}
