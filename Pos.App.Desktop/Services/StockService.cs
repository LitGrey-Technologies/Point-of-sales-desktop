using System.Data;
using System.Threading.Tasks;
using Pos.App.Desktop.Abstracts;

namespace Pos.App.Desktop.Services
{
    public interface IStockService
    {
        Task<DataTable> GetStock();
    }
    public class StockService : IStockService
    {
        private readonly GenericRepository _dbContext;

        public StockService()
        {
            _dbContext = new GenericRepository();
        }

        public Task<DataTable> GetStock()
        {
            var query = "SELECT (productId),(qty) FROM ps_gp_products where active='1'";
            return _dbContext.GetAllAsync(query);
        }
    }
}
