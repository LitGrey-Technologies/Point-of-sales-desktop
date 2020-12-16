using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Pos.App.Desktop.Models;
using Pos.App.Desktop.Services.Abstracts;

namespace Pos.App.Desktop.Services
{
    public interface IProductSaleService:IGenericService<ProductSale>
    {
        void GenerateInvoice(List<ProductSale> saleItems);
    }
    public class ProductSaleService : IProductSaleService
    {
        private readonly ITupleDetailsService _tupleDetailsService;

        public ProductSaleService(ITupleDetailsService tupleDetailsService)
        {
            _tupleDetailsService = tupleDetailsService;
        }
        public Task<bool> SaveAsync(ProductSale model)
        {
            return null;
        }

        public Task<bool> UpdateAsync(ProductSale model)
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

        public async void GenerateInvoice(List<ProductSale> saleItems)
        {
            var invoiceNumber = await _tupleDetailsService.GetCount(TupleNames.CustomerInvoice);
            
            invoiceNumber++;

        }
    }
}
