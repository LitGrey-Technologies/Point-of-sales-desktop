using Pos.App.Desktop.Abstracts;
using Pos.App.Desktop.Abstracts.Forms;
using Pos.App.Desktop.Services;
using System.Windows.Forms;

namespace Pos.App.Desktop.Modules.Product
{
    public partial class ProductRegistrationView : ViewBase
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        public ProductRegistrationView()
        {
            InitializeComponent();
            _productService = new ProductService();
            _productCategoryService = new ProductCategoryService();
            SelectedItem = new Models.Product();
            var generic = new GenericCrud<Models.Product>(this, _productService.SaveAsync,
                _productService.UpdateAsync, _productService.DeleteAsync, _productService.SearchAsync)
            {
                KeyControl = txtProductId,
                SearchBox = txtSearchBox
            };

        }

        protected override async void OnViewLoadedAsyncExecute()
        {
            var data = await _productService.GetAllAsync();
            SetDataSource(metroGrid1, data);
            SetDataSource(cmbActive, NameValuePairCollection.BooleanDataSource);
            var categories = await _productCategoryService.GetLookUps();
            SetDataSource(cmbCategoryId, categories);
        }

        public override void ViewDataGridSelectionChangedCommand(DataGridViewRow row)
        {
            txtProductId.Text = row.Cells["productId"].Value.ToString();
            txtDescription.Text = row.Cells["description"].Value.ToString();
            txtPrice.Text = row.Cells["price"].Value.ToString();
            txtQty.Text = row.Cells["qty"].Value.ToString();
            cmbCategoryId.Text = row.Cells["category"].Value.ToString();
            cmbActive.Text = row.Cells["active"].Value.ToString();
        }

        public override bool ViewValidateInputs()
        {
            if (!ViewFieldValueRequiredValidation(txtProductId.Text,"Product Id"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(txtDescription.Text, "Product Description"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(txtQty.Text, "Initial Qty"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(txtPrice.Text, "Product Price"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(cmbActive.Text, "Active/Deactivate Product"))
            {
                return false;
            }
            if (!ViewFieldValueRequiredValidation(cmbCategoryId.Text, "Product Category"))
            {
                return false;
            }
            return true;
        }

        public override T GetSelectedItem<T>()
        {
            return SelectedItem as T;
        }

        private Models.Product _selectedItem;
        public Models.Product SelectedItem
        {
            get
            {
                _selectedItem.ProductId = txtProductId.Text;
                _selectedItem.Description = txtDescription.Text;
                _selectedItem.Qty = txtQty.Text;
                _selectedItem.Price = txtPrice.Text;
                _selectedItem.CategoryId = cmbCategoryId.SelectedValue.ToString();
                _selectedItem.Active = cmbActive.SelectedValue.ToString();
                return _selectedItem;
            }
            set => _selectedItem = value;
        }

    }
}
