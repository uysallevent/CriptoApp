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
    public class PortfoyServiceDataStore : ServiceManager, IDataStore<UserPortfoyModel>
    {
        public async Task<MobileResult> AddItemAsync(UserPortfoyModel item)
        {
            MobileResult mobileResult = new MobileResult();
            try
            {
                var Client = await GetClient();
                var response = await Client.PostAsync(APIUrl + "UserPortfoy/Add", new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));
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

        public async Task<MobileResult> UpdateItemAsync(UserPortfoyModel item)
        {
            MobileResult mobileResult = new MobileResult();
            try
            {
                var Client = await GetClient();
                var response = await Client.PostAsync(APIUrl + "api/Portfoy/UpdatePortfoy", new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));
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

        public async Task<MobileResult> DeleteItemAsync(UserPortfoyModel item)
        {
            MobileResult mobileResult = new MobileResult();
            try
            {
                var Client = await GetClient();
                var response = await Client.PostAsync(APIUrl + "UserPortfoy/IsDelete", new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));
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

        public async Task<MobileResult> GetListAsync(int Id)
        {
            MobileResult mobileResult = new MobileResult();
            try
            {
                var Client = await GetClient();
                var response = await Client.GetStringAsync(APIUrl + "UserPortfoy/List?UserId=" + Id);
                mobileResult = JsonConvert.DeserializeObject<MobileResult>(response);
                return mobileResult;
            }
            catch (Exception)
            {
                AlertHelper.MessageAlert(mobileResult.Message);
                return mobileResult;
            }
        }

        public async Task<MobileResult> GetListAsync(UserPortfoyModel item)
        {
            MobileResult mobileResult = new MobileResult();
            try
            {
                var Client = await GetClient();
                var response = await Client.PostAsync(APIUrl + "UserPortfoy/GetPortfoyProfile", new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json"));
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

        public Task<MobileResult> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<MobileResult> GetItemNoParamAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public async Task<MobileResult> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }


    }
}
