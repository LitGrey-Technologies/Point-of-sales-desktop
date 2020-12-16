using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Models;
using Pos.App.Desktop.Services.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Services
{
    public interface IProductPurchaseService
    {
        Task<bool> SaveAsync(List<ProductPurchase> products, int noOfItems, double totalAmount);
    }
    public class ProductPurchaseService : IProductPurchaseService
    {
        private readonly GenericRepository _dbContext;
        private readonly ITupleDetailsService _tupleDetailsService;
        public ProductPurchaseService()
        {
            _dbContext = new GenericRepository();
            _tupleDetailsService = new TupleDetailsService();
        }
        public async Task<bool> SaveAsync(List<ProductPurchase> products, int noOfItems, double totalAmount)
        {
            var invoiceNo = await _tupleDetailsService.GetCount(TupleNames.VendorInvoice);
            var invoiceDetailNo = await _tupleDetailsService.GetCount(TupleNames.VendorInvoiceDetails);
            invoiceNo++;
            var vendorId = products[0].VendorId;
            
            var invoiceQuery = $"INSERT INTO `ps_vn_invoice` VALUES ('{invoiceNo}','','{totalAmount}','{noOfItems}','{vendorId}');";
            await _dbContext.ExecuteQueryAsync(invoiceQuery);
            await Task.Delay(100);
          
            foreach (var product in products)
            {
                invoiceDetailNo++;
                var invoiceDetailQuery = $"INSERT INTO `ps_vn_invoice_details` VALUES ('{invoiceDetailNo}','{invoiceNo}','{product.ProductId}','{product.Qty}','{product.Amount}','');";
                await _dbContext.ExecuteQueryAsync(invoiceDetailQuery);
                await Task.Delay(100);
            }



            await _tupleDetailsService.UpdateCount(TupleNames.VendorInvoice, invoiceNo);
            return await _tupleDetailsService.UpdateCount(TupleNames.VendorInvoiceDetails, invoiceDetailNo);
        }
    }
}
