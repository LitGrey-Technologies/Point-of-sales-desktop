using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Services;
using System;
using System.Collections.Generic;

namespace Pos.App.Desktop.Modules.Product
{
    public partial class ProductPurchase : ViewBase
    {
        private readonly IProductPurchaseService _productPurchaseService;
        private readonly IProductService _productService;
        private readonly IVendorService _vendorService;
        private readonly List<Models.ProductPurchase> _purchaseProduct;
        private int _noOfItems = 0;
        private double _totalAmount = 0;
        public ProductPurchase()
        {
            InitializeComponent();
            _productService = new ProductService();
            _productPurchaseService = new ProductPurchaseService();
            _vendorService = new VendorService();
            _purchaseProduct = new List<Models.ProductPurchase>();
            OnViewLoadedAsyncExecute();
        }

        private void metroButton1_Click(object sender, System.EventArgs e)
        {
            if (ViewValidateInputs())
            {
                var amount = Convert.ToInt32(txtQty.Text) * Convert.ToInt32(txtUnitPrice.Text);
                metroGrid1.Rows.Add(cmbProduct.Text, txtQty.Text, txtUnitPrice.Text, amount, cmbVendor.Text);
                _purchaseProduct.Add(new Models.ProductPurchase
                {
                    VendorId = cmbVendor.SelectedValue.ToString(),
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

        protected override async void OnViewLoadedAsyncExecute()
        {
            var vendors = await _vendorService.GetLookUps();
            SetDataSource(cmbVendor, vendors);
            var products = await _productService.GetLookUps();
            SetDataSource(cmbProduct, products);
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
            if (!ViewFieldValueRequiredValidation(cmbVendor.Text, "Vendor"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(cmbProduct.Text, "Product"))
            {
                return false;
            }
            return true;
        }

        private async void metroButton2_Click(object sender, EventArgs e)
        {
            IsBusy = true;
            var response = await _productPurchaseService.SaveAsync(_purchaseProduct, _noOfItems, _totalAmount);
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
    }
}
