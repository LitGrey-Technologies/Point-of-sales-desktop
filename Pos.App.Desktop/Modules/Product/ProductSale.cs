using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Modules.Customer;
using Pos.App.Desktop.Services;
using System;
using System.Collections.Generic;

namespace Pos.App.Desktop.Modules.Product
{
    public partial class ProductSale : ViewBase
    {
        private readonly IProductService _productService;
        private readonly IProductSaleService _productSaleService;
        private readonly ICustomerService _customerService;
        private readonly List<Models.ProductSale> _purchaseProduct;
        private int _noOfItems = 0;
        private double _totalAmount = 0;

        public ProductSale()
        {
            InitializeComponent();
            _productService = new ProductService();
            _productSaleService = new ProductSaleService();
            _customerService = new CustomerService();
            _purchaseProduct = new List<Models.ProductSale>();
            ViewLoadedAsync();
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            new CustomerRegistration().ShowDialog(this);
            ViewLoadedAsync();
        }

        protected override async void OnViewLoadedAsyncExecute()
        {
            var customers = await _customerService.GetLookUps();
            SetDataSource(cmbCustomer, customers);
            var products = await _productService.GetLookUps();
            SetDataSource(cmbProduct, products);
            cmbCustomer.SelectedIndex = -1;
            cmbProduct.SelectedIndex = -1;
            txtUnitPrice.Text = @"0";
        }

        public override bool ViewValidateInputs()
        {
            if (!ViewFieldValueRequiredValidation(txtQty.Text, "Qty"))
            {
                return false;
            }

            if (!ViewFieldValueRequiredValidation(txtUnitPrice.Text, "Unit Price"))
            {
                return false;
            }

            if (!ViewFieldValueRequiredValidation(cmbCustomer.Text, "Customer"))
            {
                return false;
            }

            if (!ViewFieldValueRequiredValidation(cmbProduct.Text, "Product"))
            {
                return false;
            }

            return true;
        }

        private async void metroButton1_Click(object sender, EventArgs e)
        {
            if (ViewValidateInputs())
            {
                var productQty = await _productService.GetProductQty(cmbProduct.SelectedValue.ToString());
                if (productQty < Convert.ToInt32(txtQty.Text))
                {
                    MessageDialog.Error($"out of stock. we don't have {txtQty.Text} qty in our stock");
                    return;
                }
                var amount = Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtUnitPrice.Text);
                metroGrid1.Rows.Add(cmbProduct.Text, txtQty.Text, txtUnitPrice.Text, amount, cmbCustomer.Text);
                _purchaseProduct.Add(new Models.ProductSale
                {
                    CustomerId = cmbCustomer.SelectedValue.ToString(),
                    ProductId = cmbProduct.SelectedValue.ToString(),
                    Qty = txtQty.Text,
                    UnitPrice = txtUnitPrice.Text,
                    Amount = amount.ToString()
                });
                _totalAmount += amount;
                _noOfItems += Convert.ToInt32(txtQty.Text);
                txtNoOfItems.Text = $@"No Of Items : {_noOfItems}";
                txtTotalAmount.Text = $@"Total Amount : {_totalAmount}";
            }
        }

        private async void metroButton2_Click_1(object sender, EventArgs e)
        {
            IsBusy = true;
            var response = await _productSaleService.SaveAsync(null);
            if (response)
            {
                MessageDialog.Information("Saved SuccessFully.");
            }
            else
            {
                MessageDialog.Error("Something went wrong.");
            }

            IsBusy = false;
        }

        private async void cmbProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduct.SelectedValue == null) return;
            txtUnitPrice.Text = (await _productService.GetProductPrice(cmbProduct.SelectedValue as string)).ToString();
        }

    }
}
