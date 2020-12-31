using System;
using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Models;
using Pos.App.Desktop.Services.Abstracts;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace Pos.App.Desktop.Services
{
    public interface IProductSaleService
    {
        Task<bool> GenerateInvoice(List<ProductSale> saleItems, int noOfItems, double totalAmount);
    }

    public class ProductSaleService : IProductSaleService
    {
        private readonly ITupleDetailsService _tupleDetailsService;
        private readonly GenericRepository _dbContext;
        private readonly IProductService _productService;
        private readonly IAccountTransactionService _transactionService;
        public ProductSaleService()
        {
            _dbContext = new GenericRepository();
            _productService = new ProductService();
            _transactionService = new AccountTransactionService();
            _tupleDetailsService = new TupleDetailsService();
        }


        public async Task<bool> GenerateInvoice(List<ProductSale> saleItems, int noOfItems, double totalAmount)
        {
            var invoiceNumber = await _tupleDetailsService.GetCount(TupleNames.CustomerInvoice);
            var invoiceDetailNumber = await _tupleDetailsService.GetCount(TupleNames.CustomerInvoiceDetails);
            invoiceNumber++;
            var customerId = saleItems[0].CustomerId;

            var invoiceQuery = $"INSERT INTO `ps_cus_invoice` VALUES ('{invoiceNumber}','','{customerId}','{totalAmount}','{noOfItems}');";
            await _dbContext.ExecuteQueryAsync(invoiceQuery);
            await Task.Delay(100);

            foreach (var item in saleItems)
            {
                invoiceDetailNumber++;
                var invoiceDetailQuery = $"INSERT INTO `ps_cus_inovoice_details` VALUES ('{invoiceDetailNumber}','{invoiceNumber}','{item.ProductId}','{item.Amount}','{item.Qty}');";
                await _dbContext.ExecuteQueryAsync(invoiceDetailQuery);
                await Task.Delay(100);
                await _productService.UpdateQty(item.ProductId, item.Qty);
                await Task.Delay(100);
            }

            await _transactionService.IncomeTransaction(Convert.ToInt32(totalAmount).ToString(), invoiceNumber.ToString());

            await _tupleDetailsService.UpdateCount(TupleNames.CustomerInvoice, invoiceNumber);
            return await _tupleDetailsService.UpdateCount(TupleNames.CustomerInvoiceDetails, invoiceDetailNumber);
        }
    }
}
