using System;
using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Models;
using Pos.App.Desktop.Services.Abstracts;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Services
{
    public interface IProductService : IGenericService<Product>
    {
        Task<ObservableCollection<NameValuePair>> GetLookUps();
        Task<int> GetProductPrice(string productId);
        Task<int> GetProductQty(string productId);
        Task<bool> UpdateQty(string productId, string qty);
    }

    public class ProductService : IProductService
    {
        private readonly GenericRepository _dbContext;
        public ProductService()
        {
            _dbContext = new GenericRepository();
        }
        public Task<bool> SaveAsync(Product model)
        {
            var query = $"INSERT INTO ps_gp_products VALUES ('{model.ProductId}','{model.Description}','{model.Qty}','{model.Price}','{model.CategoryId}','{model.Active}');";
            return _dbContext.ExecuteQueryAsync(query);
        }

        public Task<bool> UpdateAsync(Product model)
        {
            var query = $"UPDATE `ps_gp_products` SET `description` = '{model.Description}',`qty` = '{model.Qty}',`price` = '{model.Price}',`categoryid` = '{model.CategoryId}',`active` = '{model.Active}' WHERE `productId` = '{model.ProductId}';";
            return _dbContext.ExecuteQueryAsync(query);
        }

        public Task<bool> DeleteAsync(string id)
        {
            var query = $"DELETE FROM `ps_gp_products` WHERE productId='{id}';";
            return _dbContext.ExecuteQueryAsync(query);
        }

        public Task<DataTable> SearchAsync(string criteria)
        {
            var query = $"SELECT (productId),(ps_gp_products.description),(qty),(price), (ps_gp_productcategory.description) as category,(if(ps_gp_products.active=1,'YES','NO')) as active FROM ps_gp_products inner join ps_gp_productcategory on ps_gp_productcategory.categoryId=ps_gp_products.categoryId where ps_gp_products.description like '%{criteria}%';";
            return _dbContext.GetAllAsync(query);
        }

        public Task<DataTable> GetAllAsync()
        {
            var query = "SELECT (productId),(ps_gp_products.description),(qty),(price), (ps_gp_productcategory.description) as category,(if(ps_gp_products.active=1,'YES','NO')) as active FROM ps_gp_products inner join ps_gp_productcategory on ps_gp_productcategory.categoryId=ps_gp_products.categoryId;";
            return _dbContext.GetAllAsync(query);
        }

        public Task<ObservableCollection<NameValuePair>> GetLookUps()
        {
            var query = "SELECT (productId),(description) FROM ps_gp_products where active='1';";
            return _dbContext.GetNamedValuePairObservableCollectionLookUpsAsync(query);
        }

        public async Task<int> GetProductPrice(string productId)
        {
            var query = $"SELECT (price) from ps_gp_products where active='1' and productId='{productId}'";
            var result = await _dbContext.FindAsync(query);
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0].ItemArray[0]);
            }
            return -1;
        }
        public async Task<int> GetProductQty(string productId)
        {
            var query = $"SELECT (qty) from ps_gp_products where active='1' and productId='{productId}'";
            var result = await _dbContext.FindAsync(query);
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0].ItemArray[0]);
            }
            return -1;
        }

        public async Task<bool> UpdateQty(string productId, string qty)
        {
            var inStock = await GetProductQty(productId);
            await Task.Delay(100);
            var newStock = inStock - Convert.ToInt32(qty);
            var query = $"UPDATE `ps_gp_products` SET `qty` = '{newStock}' WHERE `productId` = '{productId}';";
            return await _dbContext.ExecuteQueryAsync(query);
        }
    }
}
