using System.Data;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Services.Abstracts
{
    public interface IGenericService<in T> where T : class
    {
        Task<bool> SaveAsync(T model);
        Task<bool> UpdateAsync(T model);
        Task<bool> DeleteAsync(string id);
        Task<DataTable> SearchAsync(string criteria);
        Task<DataTable> GetAllAsync();
    }
}
