using CriptoApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CriptoApp.Services
{
    public interface IDataStore<T>
    {
        Task<MobileResult> AddItemAsync(T item);
        Task<MobileResult> UpdateItemAsync(T item);
        Task<MobileResult> DeleteItemAsync(T item);
        Task<MobileResult> GetItemAsync(string id);
        Task<MobileResult> GetItemNoParamAsync(bool forceRefresh = false);
        Task<MobileResult> GetItemsAsync(bool forceRefresh = false);
        Task<MobileResult> GetListAsync(int Id);
    }
}
