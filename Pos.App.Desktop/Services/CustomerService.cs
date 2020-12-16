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

        public Task<bool> UpdateAsync(Customer model)
        {
            var query = $"UPDATE `ps_cus_customer` SET `name` = '{model.Name}',`contact_number` = '{model.Contact}',`addresss` = '{model.Address}',`email` = '{model.Email}', `active`='{model.Active}' WHERE `customerId` = '{model.CustomerId}';";
            return _dbContext.ExecuteQueryAsync(query);
        }

        public Task<bool> DeleteAsync(string id)
        {
            var query = $"DELETE FROM ps_cus_customer WHERE customerId='{id}'";
            return _dbContext.ExecuteQueryAsync(query);
        }

        public Task<DataTable> SearchAsync(string criteria)
        {
            var query = $"SELECT (customerId),(name),(contact_number),(addresss),(email),(IF(active=1,'YES','NO')) AS active FROM ps_cus_customer where name like '%{criteria}%';";
            return _dbContext.GetAllAsync(query);
        }

        public Task<DataTable> GetAllAsync()
        {
            var query = "SELECT (customerId),(name),(contact_number),(addresss),(email),(IF(active=1,'YES','NO')) AS active FROM ps_cus_customer;";
            return _dbContext.GetAllAsync(query);
        }

        public Task<ObservableCollection<NameValuePair>> GetLookUps()
        {
            var query = "SELECT (customerId),(name) FROM ps_cus_customer where active='1';";
            return _dbContext.GetNamedValuePairObservableCollectionLookUpsAsync(query);
        }
    }
}
