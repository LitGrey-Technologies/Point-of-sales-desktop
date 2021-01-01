using Pos.App.Desktop.Abstracts;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Services
{
    public interface IDashboardService
    {
        Task<int> GetTotalUsers();
        Task<int> GetTotalTransactions();
        Task<int> GetTotalIncome();
        Task<int> GetTotalExpense();
    }
    public class DashboardService : IDashboardService
    {
        private readonly GenericRepository _dbContext;
        public DashboardService()
        {
            _dbContext = new GenericRepository();
        }

        public async Task<int> GetTotalUsers()
        {
            var query = "SELECT Count(*) as Total FROM ps_us_users;";
            return await _dbContext.GetCount(query);
        }

        public async Task<int> GetTotalTransactions()
        {
            var query = "SELECT Count(*) as total FROM ps_ac_accounttransaction where date between CURDATE() - INTERVAL 30 DAY AND CURDATE();";
            return await _dbContext.GetCount(query);
        }

        public async Task<int> GetTotalIncome()
        {
            var query = "SELECT sum(amount) as Total_transactions,(if(accountId=1,'INCOME','EXPENSE')) AS transaction_type FROM ps_ac_accounttransaction where accountId=1 and date between CURDATE() - INTERVAL 30 DAY AND CURDATE();";
            return await _dbContext.GetCount(query);
        }

        public async Task<int> GetTotalExpense()
        {
            var query = "SELECT sum(amount) as Total_transactions,(if(accountId=1,'INCOME','EXPENSE')) AS transaction_type FROM ps_ac_accounttransaction where accountId=2 and date between CURDATE() - INTERVAL 30 DAY AND CURDATE();";
            return await _dbContext.GetCount(query);
        }
    }
}
