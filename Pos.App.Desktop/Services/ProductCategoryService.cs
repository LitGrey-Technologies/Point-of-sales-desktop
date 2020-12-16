using System.Collections.ObjectModel;
using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Models;
using Pos.App.Desktop.Services.Abstracts;
using System.Data;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Services
{
    public interface IProductCategoryService : IGenericService<ProductCategory>
    {
        Task<ObservableCollection<NameValuePair>> GetLookUps();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private readonly GenericRepository _dbContext;
        public ProductCategoryService()
        {
            _dbContext = new GenericRepository();
        }
        public Task<bool> SaveAsync(ProductCategory model)
        {
            var query = $"INSERT INTO ps_gp_productcategory VALUES ('{model.CategoryId}','{model.Description}','{model.Active}');";
            return _dbContext.ExecuteQueryAsync(query);
        }
        public async Task<ObservableCollection<NameValuePair>> GetLookUps()
        {
            var query = "SELECT categoryId , description FROM ps_gp_productcategory where active='1';";
            return await _dbContext.GetNamedValuePairObservableCollectionLookUpsAsync(query);
        }
        public Task<bool> UpdateAsync(ProductCategory model)
        {
            var query = $"UPDATE ps_gp_productcategory SET `description` = '{model.Description}' ,`active` = '{model.Active}' WHERE `categoryId` = '{model.CategoryId}';";
            return _dbContext.ExecuteQueryAsync(query);
        }

        public Task<bool> DeleteAsync(string id)
        {
            var query = $"DELETE FROM ps_gp_productcategory WHERE `categoryId` = '{id}';";
            return _dbContext.ExecuteQueryAsync(query);
        }

        public Task<DataTable> SearchAsync(string criteria)
        {
            var query = $"SELECT (categoryId),(description),(if(active=1,'YES','NO')) AS ACTIVE FROM pos.ps_gp_productcategory where description like '%{criteria}%';";
            return _dbContext.GetAllAsync(query);
        }

        public Task<DataTable> GetAllAsync()
        {
            var query = "SELECT (categoryId),(description),(if(active=1,'YES','NO')) AS ACTIVE FROM pos.ps_gp_productcategory;";
            return _dbContext.GetAllAsync(query);
        }
    }
}
