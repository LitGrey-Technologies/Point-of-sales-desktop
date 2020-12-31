using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Models;
using Pos.App.Desktop.Services.Abstracts;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Services
{
    public interface IAccountTransactionService
    {
        Task<bool> IncomeTransaction(string amount, string invoiceId);
        Task<bool> ExpenseTransaction(string amount, string invoiceId);
    }
    public class AccountTransactionService : IAccountTransactionService
    {
        private readonly GenericRepository _dbContext;
        private readonly ITupleDetailsService _tupleDetailsService;
        public AccountTransactionService()
        {
            _dbContext = new GenericRepository();
            _tupleDetailsService = new TupleDetailsService();
        }

        public async Task<bool> SaveAsync(AccountTransaction model)
        {
            var transactionId = await _tupleDetailsService.GetCount(TupleNames.AccountTransaction); transactionId++;
            var query = $"INSERT INTO `ps_ac_accounttransaction` VALUES ('{transactionId}','{model.Description}',sysdate(),'{model.AccountId}','{model.InvoiceId}','{model.Amount}');";
            await _dbContext.ExecuteQueryAsync(query); await Task.Delay(100);
            return await _tupleDetailsService.UpdateCount(TupleNames.AccountTransaction, transactionId);
        }

        public async Task<bool> IncomeTransaction(string amount, string invoiceId)
        {
            var model = new AccountTransaction { AccountId = Defaults.IncomeAccountId, Date = DateTime.Now, Description = "", InvoiceId = invoiceId, Amount = amount };
            return await SaveAsync(model);
        }

        public async Task<bool> ExpenseTransaction(string amount, string invoiceId)
        {
            var model = new AccountTransaction { AccountId = Defaults.ExpenseAccountId, Date = DateTime.Now, Description = "", InvoiceId = invoiceId, Amount = amount };
            return await SaveAsync(model);
        }

        public Task<DataTable> GetAllAsync(string accountId, string customerName)
        {
            return null;
        }
    }
}
