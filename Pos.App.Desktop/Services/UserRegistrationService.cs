using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Models;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;
using Pos.App.Desktop.Services.Abstracts;

namespace Pos.App.Desktop.Services
{
    public interface IUserRegistrationService:IGenericService<User>
    {
        Task<ObservableCollection<NameValuePair>> GetLookUpsAsync();
    }
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly GenericRepository _dbContext;

        public UserRegistrationService()
        {
            _dbContext = new GenericRepository();
        }

        public async Task<DataTable> GetAllAsync()
        {
            var userQuery = "SELECT (userId),(name),(email),(description), IF(ps_us_users.active = 1, 'YES', 'No') as Active  FROM ps_us_users  inner join ps_gp_roles on ps_gp_roles.roleId = ps_us_users.roleId;";
            return await _dbContext.GetAllAsync(userQuery);
        }
        public async Task<ObservableCollection<NameValuePair>> GetLookUpsAsync()
        {
            var userQuery = "SELECT (userId),(name) FROM ps_us_users WHERE active='1'";
            return await _dbContext.GetNamedValuePairObservableCollectionLookUpsAsync(userQuery);
        }

        public async Task<bool> DeleteAsync(string userId)
        {
            var userQuery = $"DELETE FROM ps_us_users WHERE `userId` = '{userId}';";
            return await _dbContext.ExecuteQueryAsync(userQuery);
        }

        public async Task<DataTable> SearchAsync(string criteria)
        {
            var userQuery = $"SELECT (userId),(name),(email),(description), IF(ps_us_users.active = 1, 'YES', 'No') as Active  FROM ps_us_users  inner join ps_gp_roles on ps_gp_roles.roleId = ps_us_users.roleId where ps_us_users.name like '%{criteria}%';;";
            return await _dbContext.GetAllAsync(userQuery);
        }
        public async Task<bool> SaveAsync(User model)
        {
            var userQuery = $"INSERT INTO ps_us_users VALUES ('{model.UserId}','{model.Name}','{model.Password}','{model.Email}','{model.Active}','{model.RoleId}')";
            return await _dbContext.ExecuteQueryAsync(userQuery);
        }
        public async Task<bool> UpdateAsync(User model)
        {
            var userQuery = $"UPDATE ps_us_users SET `name`= '{model.Name}',`email` ='{model.Email}',`active` ='{model.Active}',`roleId` = '{model.RoleId}' WHERE `userId` = '{model.UserId}';";
            return await _dbContext.ExecuteQueryAsync(userQuery);
        }
    }
}
