using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Models;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Services
{
    public interface IAuthenticationService
    {
        Task<DataTable> Authenticate(Login model);
        Task<DataTable> GetChild(string moduleId, string userId);
    }
    public class AuthenticationService : IAuthenticationService
    {
        private readonly GenericRepository _dbContext;

        public AuthenticationService()
        {
            _dbContext = new GenericRepository();
        }

        public async Task<DataTable> Authenticate(Login model)
        {
            var moduleQuery = $"SELECT * FROM ps_us_userpermissions inner join ps_us_users on ps_us_userpermissions.userId = ps_us_users.userId right join ps_ap_appmenu on ps_ap_appmenu.menuId=ps_us_userpermissions.menuId where ps_us_users.userId='{model.UserId}'and ps_ap_appmenu.moduleId='0' and ps_ap_appmenu.active='1';";
            var userQuery = $"select (name),(roleId),(active) from ps_us_users where userId='{model.UserId}' and password = '{model.Password}'";
            var login = await _dbContext.FindAsync(userQuery);
            if (login.Rows.Count == 0)
            {
                MessageDialog.Error("Invalid username/password.");
                return null;
            }
            var isActive = Convert.ToBoolean(login.Rows[0].ItemArray[2]);
            if (!isActive)
            {
                MessageDialog.Error("Your account is deactivated by admin. kindly contact your administration.");
                return null;
            }
            Session.AddItem("CURRENT_USER_ID", model.UserId);
            return await _dbContext.GetAllAsync(moduleQuery);
        }

        public async Task<DataTable> GetChild(string moduleId, string userId)
        {
            var childQuery = $"SELECT * FROM ps_us_userpermissions inner join ps_us_users on ps_us_userpermissions.userId = ps_us_users.userId right join ps_ap_appmenu on ps_ap_appmenu.menuId=ps_us_userpermissions.menuId where ps_us_users.userId='{userId}' and ps_ap_appmenu.moduleId='{moduleId}' and ps_ap_appmenu.active='1';";
            var child = await _dbContext.GetAllAsync(childQuery);
            return child;
        }
    }
}
