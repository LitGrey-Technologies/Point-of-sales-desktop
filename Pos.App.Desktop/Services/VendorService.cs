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
        Task<DataTable> VendorHistory(string vendorId);
        Task<DataTable> VendorHistoryDetails(string invoiceId);

    }
    public class VendorService : IVendorService
    {
        private readonly GenericRepository _dbContext;

        public VendorService()
        {
            _dbContext = new GenericRepository();
        }
        public async Task<bool> SaveAsync(Vendor model)
        {
            var query = $"INSERT INTO `ps_vn_vendor` VALUES ('{model.VendorId}','{model.Name}','{model.Contact}',SYSDATE(),'{model.Email}',0,{model.Active});";
            return await _dbContext.ExecuteQueryAsync(query);
        }

        public async Task<bool> UpdateAsync(Vendor model)
        {
            var query = $"UPDATE `ps_vn_vendor` SET `name` = '{model.Name}',`contactNumber` = '{model.Contact}',`email` = '{model.Email}' ,`active` ='{model.Active}' WHERE `vendorId` = '{model.VendorId}';";
            return await _dbContext.ExecuteQueryAsync(query);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var query = $"DELETE FROM ps_vn_vendor WHERE `vendorId` = '{id}'";
            return await _dbContext.ExecuteQueryAsync(query);
        }

        public async Task<DataTable> SearchAsync(string criteria)
        {
            var query = $"SELECT (vendorId),(name),(contactNumber),(regDate),(email),(balance),(if(active=1,'YES','NO')) AS ACTIVE FROM pos.ps_vn_vendor where name like '%{criteria}%'";
            return await _dbContext.GetAllAsync(query);
        }

        public async Task<DataTable> GetAllAsync()
        {
            var query = "SELECT (vendorId),(name),(contactNumber),(regDate),(email),(balance),(if(active=1,'YES','NO')) AS ACTIVE FROM ps_vn_vendor;";
            return await _dbContext.GetAllAsync(query);
        }

        public async Task<ObservableCollection<NameValuePair>> GetLookUps()
        {
            var query = "SELECT (vendorId),(name) FROM ps_vn_vendor where active='1';";
            return await _dbContext.GetNamedValuePairObservableCollectionLookUpsAsync(query);
        }

        public async Task<DataTable> VendorHistory(string vendorId)
        {
            var query = $"SELECT (InvoiceId),(Amount),(noOfItems) as Total_Purchased_Items FROM ps_vn_invoice where VendorId='{vendorId}';";
            return await _dbContext.GetAllAsync(query);
        }

        public async Task<DataTable> VendorHistoryDetails(string invoiceId)
        {
            var query = $"SELECT (detailId),(ps_gp_products.description),(ps_vn_invoice_details.Qty),(Amount) FROM ps_vn_invoice_details inner join ps_gp_products on ps_gp_products.productId=ps_vn_invoice_details.productId where ps_vn_invoice_details.InvoiceId='{invoiceId}';";
            return await _dbContext.GetAllAsync(query);
        }
    }
}
