using System.Collections.ObjectModel;
using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Models;
using Pos.App.Desktop.Services.Abstracts;
using System.Data;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Services
{
    public interface ICustomerService : IGenericService<Customer>
    {
        Task<ObservableCollection<NameValuePair>> GetLookUps();
        Task<DataTable> CustomerHistory(string customerId);
        Task<DataTable> CustomerHistoryDetails(string invoiceId);
    }
    public class CustomerService : ICustomerService
    {
        private readonly GenericRepository _dbContext;

        public CustomerService()
        {
            _dbContext = new GenericRepository();
        }

        public Task<bool> SaveAsync(Customer model)
        {
            var query = $"INSERT INTO `ps_cus_customer` VALUES ('{model.CustomerId}','{model.Name}','{model.Contact}','{model.Address}','{model.Email}',0,1);";
            return _dbContext.ExecuteQueryAsync(query);
        }

        public async Task<bool> UpdateAsync(Customer model)
        {
            var query = $"UPDATE `ps_cus_customer` SET `name` = '{model.Name}',`contact_number` = '{model.Contact}',`addresss` = '{model.Address}',`email` = '{model.Email}', `active`='{model.Active}' WHERE `customerId` = '{model.CustomerId}';";
            return await _dbContext.ExecuteQueryAsync(query);
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var query = $"DELETE FROM ps_cus_customer WHERE customerId='{id}'";
            return await _dbContext.ExecuteQueryAsync(query);
        }

        public async Task<DataTable> SearchAsync(string criteria)
        {
            var query = $"SELECT (customerId),(name),(contact_number),(addresss),(email),(IF(active=1,'YES','NO')) AS active FROM ps_cus_customer where name like '%{criteria}%';";
            return await _dbContext.GetAllAsync(query);
        }

        public async Task<DataTable> GetAllAsync()
        {
            var query = "SELECT (customerId),(name),(contact_number),(addresss),(email),(IF(active=1,'YES','NO')) AS active FROM ps_cus_customer;";
            return await _dbContext.GetAllAsync(query);
        }

        public async Task<ObservableCollection<NameValuePair>> GetLookUps()
        {
            var query = "SELECT (customerId),(name) FROM ps_cus_customer where active='1';";
            return await _dbContext.GetNamedValuePairObservableCollectionLookUpsAsync(query);
        }

        public async Task<DataTable> CustomerHistory(string customerId)
        {
            var query = $"SELECT (InvoiceId),(Amount),(NoOfItemPurchased) as Total_Purchased_Items FROM ps_cus_invoice where `CustomerId`='{customerId}';";
            return await _dbContext.GetAllAsync(query);
        }

        public async Task<DataTable> CustomerHistoryDetails(string invoiceId)
        {
            var query = $"SELECT (InvoiceId),(Amount),(NoOfItemPurchased) as Total_Purchased_Items FROM ps_cus_invoice where InvoiceId='{invoiceId}';";
            return await _dbContext.GetAllAsync(query);
        }
    }
}
