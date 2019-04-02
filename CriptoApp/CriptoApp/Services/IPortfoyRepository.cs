using CriptoApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CriptoApp.Services
{
    public interface IPortfoyRepository
    {
        Task<IEnumerable<UserPortfoyModel>> GetPortfoyAsync();

        Task<UserPortfoyModel> GetPortfoyByIdAsync(int id);

        Task<bool> AddPortfoyAsync(UserPortfoyModel userPortfoyModel);

        Task<bool> UpdateProductAsync(UserPortfoyModel userPortfoyModel);

        Task<bool> RemovePortfoyAsync(int id);

        Task<IEnumerable<UserPortfoyModel>> QueryPortfoyAsync(Func<UserPortfoyModel, bool> predicate);
    }
}
