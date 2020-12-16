using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Models;
using Pos.App.Desktop.Services.Abstracts;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Services
{
    public interface IVendorService : IGenericService<Vendor>
    {
        Task<ObservableCollection<NameValuePair>> GetLookUps();
    }
    public class VendorService : IVendorService
    {
        private readonly GenericRepository _dbContext;

        public VendorService()
        {
            _dbContext = new GenericRepository();
        }
        public Task<bool> SaveAsync(Vendor model)
        {
            var query = $"INSERT INTO `ps_vn_vendor` VALUES ('{model.VendorId}','{model.Name}','{model.Contact}',SYSDATE(),'{model.Email}',0,{model.Active});";
            return _dbContext.ExecuteQueryAsync(query);
        }

        public Task<bool> UpdateAsync(Vendor model)
        {
            var query = $"UPDATE `ps_vn_vendor` SET `name` = '{model.Name}',`contactNumber` = '{model.Contact}',`email` = '{model.Email}' ,`active` ='{model.Active}' WHERE `vendorId` = '{model.VendorId}';";
            return _dbContext.ExecuteQueryAsync(query);
        }

        public Task<bool> DeleteAsync(string id)
        {
            var query = $"DELETE FROM ps_vn_vendor WHERE `vendorId` = '{id}'";
            return _dbContext.ExecuteQueryAsync(query);
        }

        public Task<DataTable> SearchAsync(string criteria)
        {
            var query = $"SELECT (vendorId),(name),(contactNumber),(regDate),(email),(balance),(if(active=1,'YES','NO')) AS ACTIVE FROM pos.ps_vn_vendor where name like '%{criteria}%'";
            return _dbContext.GetAllAsync(query);
        }

        public Task<DataTable> GetAllAsync()
        {
            var query = "SELECT (vendorId),(name),(contactNumber),(regDate),(email),(balance),(if(active=1,'YES','NO')) AS ACTIVE FROM ps_vn_vendor;";
            return _dbContext.GetAllAsync(query);
        }

        public Task<ObservableCollection<NameValuePair>> GetLookUps()
        {
            var query = "SELECT (vendorId),(name) FROM ps_vn_vendor where active='1';";
            return _dbContext.GetNamedValuePairObservableCollectionLookUpsAsync(query);
        }
    }
}
