using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Models;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Services
{
    public interface IUserRoleService
    {
        Task<ObservableCollection<NameValuePair>> GetLookUps();
        Task<DataTable> GetAllAsync();
        Task<bool> SaveAsync(UserRole model);
        Task<bool> DeleteAsync(string key);
        Task<bool> UpdateAsync(UserRole model);
        Task<DataTable> SearchAsync(string criteria);
    }
    public class UserRoleService : IUserRoleService
    {
        private readonly GenericRepository _dbContext;

        public UserRoleService()
        {
            _dbContext = new GenericRepository();
        }

        public async Task<ObservableCollection<NameValuePair>> GetLookUps()
        {
            var query = "SELECT roleId , description FROM ps_gp_roles where active='1';";
            return await _dbContext.GetNamedValuePairObservableCollectionLookUpsAsync(query);
        }

        public Task<DataTable> GetAllAsync()
        {
            var query = "SELECT roleId, description, IF(active = 1, 'YES', 'No') as Active FROM ps_gp_roles;";
            return _dbContext.GetAllAsync(query);
        }

        public async Task<bool> SaveAsync(UserRole model)
        {
            var query = $"INSERT INTO ps_gp_roles VALUES ('{model.RoleId}', '{model.Description}','{model.Active}');";
            return await _dbContext.ExecuteQueryAsync(query);
        }
        public async Task<bool> UpdateAsync(UserRole model)
        {
            var query = $"UPDATE ps_gp_roles SET DESCRIPTION ='{model.Description}' , ACTIVE ='{model.Active}' WHERE RoleId='{model.RoleId}'";
            return await _dbContext.ExecuteQueryAsync(query);
        }

        public Task<DataTable> SearchAsync(string criteria)
        {
            var query = $"SELECT roleId, description, IF(active = 1, 'YES', 'No') as Active FROM ps_gp_roles where description like '%{criteria}%'";
            return _dbContext.GetAllAsync(query);
        }

        public Task<bool> DeleteAsync(string key)
        {
            var query = $"DELETE FROM ps_gp_roles where RoleId='{key}'";
            return _dbContext.ExecuteQueryAsync(query);
        }
    }
}
