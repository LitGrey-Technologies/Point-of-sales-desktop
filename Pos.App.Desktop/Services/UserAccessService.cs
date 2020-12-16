using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Services.Abstracts;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Services
{
    public interface IUserAccessService
    {
        Task<DataTable> GetMenuAsync();
        Task<bool> SaveAsync(List<NameValuePair<bool>> menIds, string id);
        Task<DataTable> GetUserLevelMenuAsync(string userId);
    }
    public class UserAccessService : IUserAccessService
    {
        private readonly GenericRepository _dbContext;
        private readonly ITupleDetailsService _tupleDetailsService;

        public UserAccessService()
        {
            _dbContext = new GenericRepository();
            _tupleDetailsService = new TupleDetailsService();
        }
        public async Task<DataTable> GetMenuAsync()
        {
            var query = "SELECT (menuId),(title),(moduleId) FROM ps_ap_appmenu where active='1';";
            return await _dbContext.GetAllAsync(query);
        }
        public async Task<DataTable> GetUserLevelMenuAsync(string userId)
        {
            var query = $"SELECT (userId),(title),(moduleId) FROM ps_us_userpermissions inner join ps_ap_appmenu on ps_ap_appmenu.menuId=ps_us_userpermissions.menuId where ps_ap_appmenu.active='1' and userId='{userId}';";
            return await _dbContext.GetAllAsync(query);
        }
        public async Task<bool> SaveAsync(List<NameValuePair<bool>> menIds, string id)
        {
            var count = await _tupleDetailsService.GetCount(TupleNames.UserAccess);
            var deleteQuery = $"Delete From ps_us_userpermissions WHERE userId='{id}'";
            await _dbContext.ExecuteQueryAsync(deleteQuery);
            await Task.Delay(100);
            foreach (var menId in menIds)
            {
                count++;
                var query = $"INSERT INTO ps_us_userpermissions VALUES ('{id}','{menId.Name}', '{count}')";
                await _dbContext.ExecuteQueryAsync(query);
                await Task.Delay(100);
            }

            return await _tupleDetailsService.UpdateCount(TupleNames.UserAccess, count);
        }

        public async Task<bool> DeleteAsync(string menuId, string userId)
        {
            var query = $"DELETE FROM ps_us_userpermissions WHERE menuId='{menuId}' and userId='{userId}'";
            return await _dbContext.ExecuteQueryAsync(query);
        }
    }
}
