using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Models;
using Pos.App.Desktop.Services.Abstracts;
using System.Data;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Services
{
    public interface IAccountService : IGenericService<Account>
    {

    }

    public class AccountService : IAccountService
    {
        private readonly GenericRepository _dbContext;
        private readonly ITupleDetailsService _tupeDetailsService;
        public AccountService()
        {
            _dbContext = new GenericRepository();
            _tupeDetailsService = new TupleDetailsService();
        }
        public async Task<bool> SaveAsync(Account model)
        {
            var accountNumber = await _tupeDetailsService.GetCount(TupleNames.Account);
            accountNumber++;
            var query = $"INSERT INTO `ps_ac_account` VALUES ('{accountNumber}','{model.Description}','{model.Active}','{model.TypeId}');";
            await _dbContext.ExecuteQueryAsync(query);
            await Task.Delay(100);
            return await _tupeDetailsService.UpdateCount(TupleNames.Account, accountNumber);
        }

        public Task<bool> UpdateAsync(Account model)
        {
            return null;
        }

        public Task<bool> DeleteAsync(string id)
        {
            return null;
        }

        public Task<DataTable> SearchAsync(string criteria)
        {
            return null;
        }

        public Task<DataTable> GetAllAsync()
        {
            return null;
        }
    }
}
