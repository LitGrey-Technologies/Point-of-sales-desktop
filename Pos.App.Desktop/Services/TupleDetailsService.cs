using System;
using Pos.App.Desktop.Abstracts;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Services
{
    public interface ITupleDetailsService
    {
        Task<int> GetCount(string key);
        Task<bool> UpdateCount(string key, int count);
    }

    public class TupleDetailsService : ITupleDetailsService
    {
        private readonly GenericRepository _dbContext;
        public TupleDetailsService()
        {
            _dbContext = new GenericRepository();
        }

        public async Task<int> GetCount(string key)
        {
            var query = $"SELECT (count) from ps_ap_tuple_details where name='{key}'";
            var data = await _dbContext.FindAsync(query);
            return Convert.ToInt32(data.Rows[0].ItemArray[0]);
        }
        public async Task<bool> UpdateCount(string key, int count)
        {
            var query = $"UPDATE ps_ap_tuple_details SET COUNT='{count}' where name='{key}'";
            return await _dbContext.ExecuteQueryAsync(query);
        }
    }
}
